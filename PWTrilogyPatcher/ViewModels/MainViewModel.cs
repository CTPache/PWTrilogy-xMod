using CommunityToolkit.Mvvm.Input;
using PWTrilogyPatcher.Services;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;

namespace PWTrilogyPatcher.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string PatchButtonText => LocalizationService.Instance.BtnPatch;
    public string CreditsButtonText => LocalizationService.Instance.BtnCredits;
    public string ExitButtonText => LocalizationService.Instance.BtnExit;

    public MainViewModel()
    {
        LocalizationService.Instance.LanguageChanged += OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        OnPropertyChanged(nameof(PatchButtonText));
        OnPropertyChanged(nameof(CreditsButtonText));
        OnPropertyChanged(nameof(ExitButtonText));
    }

    //https://brockallen.com/2016/09/24/process-start-for-urls-on-net-core/
    public static void OpenBrowser(string url)
    {
        try
        {
            Process.Start(url);
        }
        catch
        {
            // hack because of this: https://github.com/dotnet/corefx/issues/10361
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                throw;
            }
        }
    }

    [RelayCommand]
    private void CreditsButton()
    {
        OpenBrowser("https://github.com/Traducciones-Kurain/PWTrilogy-ESP/blob/master/README.md#cr%C3%A9ditos");
    }

    [RelayCommand]
    private void CloseButton()
    {
        App.Current?.Shutdown();
    }

    [RelayCommand]
    private void TKButton()
    {
        OpenBrowser("https://twitter.com/Trad_Kurain");
    }

    [RelayCommand]
    private void TSButton()
    {
        OpenBrowser("https://tradusquare.es");
    }
}
