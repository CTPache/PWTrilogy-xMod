using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using PWTrilogyPatcher.CustomMara;
using PWTrilogyPatcher.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PWTrilogyPatcher.ViewModels;

public enum PatcherStatus
{
    NoFolder,
    InvalidFolder,
    ValidFolder,
    Downloading,
    Patching,
    PatchError,
    PatchSuccess
}

public enum GamePlatform
{
    Steam,
    Xbox
}

public partial class PatcherViewModel : ViewModelBase
{
    public string PathWatermark => LocalizationService.Instance.PathWatermark;
    public string VersionLabel => LocalizationService.Instance.VersionLabel;
    public string[] TargetVersions => LocalizationService.Instance.TargetVersions;
    public string PatchButtonText => LocalizationService.Instance.BtnPatch;
    public string BackButtonText => LocalizationService.Instance.BtnBack;

    private static bool didForcedUpdate = false;
    private bool detectedPath = false;

    public PatcherStatus PatcherStatus
    {
        get => patcherStatus;
        set
        {
            patcherStatus = value;
            UpdateStatusMessage();
        }
    }

    private void UpdateStatusMessage()
    {
        switch (patcherStatus)
        {
            default:
            case PatcherStatus.NoFolder:
                Status = LocalizationService.Instance.StatusNoFolder;
                break;
            case PatcherStatus.InvalidFolder:
                Status = LocalizationService.Instance.StatusInvalidFolder;
                break;
            case PatcherStatus.ValidFolder:
                Status = $"{LocalizationService.Instance.GetStatusPlatformDetected(GetPlatformString())}{Environment.NewLine}{LocalizationService.Instance.StatusReadyToPatch}";
                break;
            case PatcherStatus.Downloading:
                Status = LocalizationService.Instance.StatusDownloading;
                break;
            case PatcherStatus.Patching:
                Status = LocalizationService.Instance.StatusPatching;
                break;
            case PatcherStatus.PatchError:
                Status = LocalizationService.Instance.StatusPatchError;
                break;
            case PatcherStatus.PatchSuccess:
                Status = LocalizationService.Instance.StatusPatchSuccess;
                break;
        }
    }

    public string GamePath
    {
        get => gamePath;
        set
        {
            this.SetProperty(ref gamePath, value);

            if (string.IsNullOrEmpty(value))
            {
                PatcherStatus = PatcherStatus.NoFolder;
                CanPatch = false;
                return;
            }

            if (CheckValidGameFolder(value, true))
            {
                PatcherStatus = PatcherStatus.ValidFolder;
                CanPatch = true;
                return;
            }

            PatcherStatus = PatcherStatus.InvalidFolder;
            CanPatch = false;
        }
    }
    
    public string ProgressText
    {
        get => progressText;
        set
        {
            this.SetProperty(ref progressText, value);
            UpdateProgress();
        }
    }

    public string TotalText
    {
        get => totalText;
        set
        {
            this.SetProperty(ref totalText, value);
            UpdateProgress();
        }
    }

    private PatcherStatus patcherStatus;
    private string gamePath = string.Empty;
    private string progressText = string.Empty;
    private string totalText = string.Empty;
    private bool updateMode = false;

    [ObservableProperty]
    private string status = string.Empty;

    [ObservableProperty]
    private bool canPatch;

    [ObservableProperty]
    private bool startedPatch;

    [ObservableProperty]
    private GamePlatform gamePlatform;

    [ObservableProperty]
    private TargetPlatform targetPlatform;

    [ObservableProperty]
    private int selectedTargetIndex;

    partial void OnSelectedTargetIndexChanged(int value)
    {
        TargetPlatform = (TargetPlatform)value;
    }

    [ObservableProperty]
    private string headerStatus = string.Empty;

    public PatcherViewModel()
    {
        updateMode = App.UpdateMode;

        HeaderStatus = LocalizationService.Instance.HeaderSelectPath;
        LocalizationService.Instance.LanguageChanged += RefreshLocalizedStrings;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            TargetPlatform = TargetPlatform.Linux;
            SelectedTargetIndex = 2;
        }
        else
        {
            TargetPlatform = TargetPlatform.Win32;
            SelectedTargetIndex = 0;
        }

        if (updateMode)
        {
            GamePath = Directory.GetCurrentDirectory();

            if (!didForcedUpdate)
            {
                didForcedUpdate = true;
                StartPatch();
                return;
            }

            detectedPath = true;
        }
        else
        {
            var steamPath = SteamUtils.GetSteamPath();
            if (!string.IsNullOrWhiteSpace(steamPath))
            {
                var gamePath = SteamUtils.GetSteamGamePath(steamPath);
                if (!string.IsNullOrWhiteSpace(gamePath))
                {
                    GamePath = gamePath;
                    detectedPath = true;
                }
            }
        }

        if (detectedPath)
        {
            Status = $"{LocalizationService.Instance.StatusDetectedFolder}{Environment.NewLine}{Environment.NewLine}{Status}";
            return;
        }

        PatcherStatus = PatcherStatus.NoFolder;
    }

    private void RefreshLocalizedStrings()
    {
        HeaderStatus = LocalizationService.Instance.HeaderSelectPath;
        OnPropertyChanged(nameof(PathWatermark));
        OnPropertyChanged(nameof(VersionLabel));
        OnPropertyChanged(nameof(TargetVersions));
        OnPropertyChanged(nameof(PatchButtonText));
        OnPropertyChanged(nameof(BackButtonText));

        if (PatcherStatus == PatcherStatus.Downloading)
        {
            UpdateDownloadProgress();
        }
        else if (PatcherStatus == PatcherStatus.Patching)
        {
            UpdatePatchProgress();
        }
        else
        {
            UpdateStatusMessage();
            if (detectedPath && PatcherStatus == PatcherStatus.ValidFolder)
            {
                Status = $"{LocalizationService.Instance.StatusDetectedFolder}{Environment.NewLine}{Environment.NewLine}{Status}";
            }
        }
    }

    [RelayCommand]
    private async Task OpenFolder()
    {
        var storageService = App.Current?.Services?.GetService<IStorageService>();
        if (storageService is null) return; // throw new NullReferenceException("Missing File Service instance.")

        var folder = await storageService.OpenFolderAsync();
        if (folder is null) return;

        GamePath = folder.TryGetLocalPath();
    }

    private bool isDecrypting = false;

    [RelayCommand]
    private async Task StartPatch()
    {
        CanPatch = false;
        StartedPatch = true;

        string? tempDecryptedZip = null;

        try
        {
            ProgressText = string.Empty;
            TotalText = string.Empty;

            var progress = new Progress<(string, string)>(value =>
            {
                ProgressText = value.Item1;
                TotalText = value.Item2;
            });

            var gamePath = GetContentFolder(GamePath);
            string patchZipPath;

            if (EmbeddedPatchManager.HasEmbeddedPayload())
            {
                PatcherStatus = PatcherStatus.Patching;
                isDecrypting = true;
                Status = LocalizationService.Instance.StatusValidatingAndDecrypting;

                if (!EmbeddedPatchManager.TryDeriveKey(gamePath, out var key, out var validatedFile))
                {
                    throw new Exception(LocalizationService.Instance.OriginalExeNotFoundError);
                }

                tempDecryptedZip = Path.Combine(Path.GetTempPath(), $"patch_{Path.GetRandomFileName()}.zip");
                await EmbeddedPatchManager.DecryptPayloadAsync(key!, tempDecryptedZip, progress);
                isDecrypting = false;
                patchZipPath = tempDecryptedZip;
            }
            else
            {
                var platform = GetPlatformString();
                string downloadPath = $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}Patch-{platform}.zip";

                if (!File.Exists(downloadPath))
                {
                    PatcherStatus = PatcherStatus.Downloading;

                    var downloadUrl = $"https://github.com/Traducciones-Kurain/PWTrilogy-ESP/releases/latest/download/Patch-{platform}.zip";
                    await GetFileAsync(downloadUrl, downloadPath, progress);
                }

                patchZipPath = downloadPath;
            }

            PatcherStatus = PatcherStatus.Patching;
            Status = LocalizationService.Instance.StatusPatching;

            var patchProcess = new PatchProcessAsync(gamePath, gamePath, patchZipPath);

            var result = await patchProcess.ApplyTranslation(progress, TargetPlatform);
            if (result.Item1 != 0)
            {
                throw new Exception($"[Mara] {result.Item2}");
            }

            // Configure Steam launch options if applicable
            try
            {
                var steamPath = SteamUtils.GetSteamPath();
                if (!string.IsNullOrWhiteSpace(steamPath))
                {
                    if (TargetPlatform == TargetPlatform.Linux)
                    {
                        SteamUtils.SetSteamLaunchOptions(steamPath, "787480", "./PWAAT.x86_64 %command%");
                    }
                    else
                    {
                        SteamUtils.ClearSteamLaunchOptions(steamPath, "787480");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SteamLaunchOptions] {ex.Message}");
            }

            if (updateMode)
            {
                Process.Start("explorer", "steam://rungameid/787480");
                App.Current?.Shutdown();
            }

            PatcherStatus = PatcherStatus.PatchSuccess;
        }
        catch (Exception e)
        {
            PatcherStatus = PatcherStatus.PatchError;

            var errorLogFile = $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}error.log";
            File.WriteAllText(errorLogFile, $"{e.Message}{Environment.NewLine}{e.StackTrace}");
        }
        finally
        {
            isDecrypting = false;
            if (!string.IsNullOrEmpty(tempDecryptedZip) && File.Exists(tempDecryptedZip))
            {
                try
                {
                    File.Delete(tempDecryptedZip);
                }
                catch {}
            }
            CanPatch = true;
        }
    }

    private void UpdateDownloadProgress()
    {
        Status = LocalizationService.Instance.GetDownloadingProgressStatus(ProgressText, TotalText);
    }

    private void UpdatePatchProgress()
    {
        if (isDecrypting)
        {
            Status = LocalizationService.Instance.GetDecryptingStatus(ProgressText, TotalText);
        }
        else
        {
            Status = LocalizationService.Instance.GetPatchingProgressStatus(ProgressText, TotalText);
        }
    }

    private void UpdateProgress()
    {
        if (PatcherStatus == PatcherStatus.Downloading)
        {
            UpdateDownloadProgress();
        }

        if (PatcherStatus == PatcherStatus.Patching)
        {
            UpdatePatchProgress();
        }
    }

    private string GetPlatformString()
    {
        switch(GamePlatform)
        {
            case GamePlatform.Steam:
                return "Steam";
            case GamePlatform.Xbox:
                return "Xbox";
        }

        return string.Empty;
    }

    private bool CheckRootFiles(string path)
    {
        var exeWin = Path.Combine(path, "PWAAT.exe");
        var exeLinux = Path.Combine(path, "PWAAT.x86_64");
        if (!File.Exists(exeWin) && !File.Exists(exeLinux)) return false;

        var dataPath = Path.Combine(path, "PWAAT_Data");
        if (!Directory.Exists(dataPath)) return false;

        return true;
    }

    private string GetContentFolder(string path)
    {
        var contentPath = Path.Combine(path, "Content");

        if (Directory.Exists(contentPath) && CheckRootFiles(contentPath))
        {
            return contentPath;
        }

        return path;
    }

    private bool CheckValidGameFolder(string path, bool setGamePlatform)
    {
        var gamePath = GetContentFolder(path);

        if (!CheckRootFiles(gamePath)) return false;

        var dataPath = Path.Combine(gamePath, "PWAAT_Data");

        var steamAssemblyPath = Path.Combine(dataPath, "Managed", "Assembly-CSharp.dll");
        if (File.Exists(steamAssemblyPath))
        {
            if (setGamePlatform)
            {
                GamePlatform = GamePlatform.Steam;
            }

            return true;
        }

        var metadataPath = Path.Combine(dataPath, "il2cpp_data", "Metadata", "global-metadata.dat");
        if (File.Exists(metadataPath))
        {
            if (setGamePlatform)
            {
                GamePlatform = GamePlatform.Xbox;
            }

            return true;
        }

        return false;
    }

    // https://github.com/TraduSquare/Mara/blob/b3518f380786b1cd5a14e7b60168c42bdce1623c/Mara.Lib/Common/Internet.cs
    private async Task GetFileAsync(string url, string path, IProgress<(string, string)> progress)
    {
        var random = new Random();
        url += $"?random={random.Next()}";
        using var client = new WebClient();
        client.DownloadProgressChanged += (s, e) => progress.Report(($"{decimal.Truncate(decimal.Divide(e.BytesReceived, 1048576))}", $"{decimal.Truncate(decimal.Divide(e.TotalBytesToReceive, 1048576))}"));
        await client.DownloadFileTaskAsync(url, path);
    }
}

public class DesignPatcherViewModel : PatcherViewModel
{
    public DesignPatcherViewModel() : base()
    {

    }
}

public class DesignPatcherViewModelDownloading : PatcherViewModel
{
    public DesignPatcherViewModelDownloading() : base()
    {
        CanPatch = false;
        StartedPatch = true;

        PatcherStatus = PatcherStatus.Downloading;
    }
}

public class DesignPatcherViewModelPatchingDone : PatcherViewModel
{
    public DesignPatcherViewModelPatchingDone() : base()
    {
        CanPatch = true;
        StartedPatch = true;

        PatcherStatus = PatcherStatus.PatchSuccess;
    }
}

public class DesignPatcherViewModelPatchingError : PatcherViewModel
{
    public DesignPatcherViewModelPatchingError() : base()
    {
        CanPatch = true;
        StartedPatch = true;

        PatcherStatus = PatcherStatus.PatchError;
    }
}
