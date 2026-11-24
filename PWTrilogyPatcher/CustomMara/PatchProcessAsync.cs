using Mara.Lib.Common;
using Mara.Lib.Configs;
using Mara.Lib;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PWTrilogyPatcher.CustomMara;

public enum TargetPlatform
{
    Win32,
    Win64,
    Linux
}

// based on https://github.com/TraduSquare/Mara/blob/0b0879ae54e373708f6729de6acf70c1a06399a8/Mara.Lib/Platforms/PatchProcess.cs
// and      https://github.com/TraduSquare/Mara/blob/0b0879ae54e373708f6729de6acf70c1a06399a8/Mara.Lib/Platforms/Generic/Main.cs
public class PatchProcessAsync
{
    private MaraConfig maraConfig;
    private string tempFolder;
    private string oriFolder;
    private string outFolder;
    private string filePath;

    public PatchProcessAsync(string oriFolder, string outFolder, string filePath)
    {
        this.oriFolder = oriFolder;
        this.outFolder = outFolder;
        this.filePath = filePath;
        GenerateTempFolder();
        ExtractPatch();
    }

    public async Task<(int, string)> ApplyTranslation(IProgress<(string, string)> progress, TargetPlatform targetPlatform = TargetPlatform.Win32)
    {
        // Step 1: In-place decrypt of vanilla StreamingAssets (unity3d, bin, mdt, cho, mh)
        await Task.Run(() => CapcomCrypto.DecryptStreamingAssets(oriFolder));

        // Step 2: Copy new files directly if 'copy' folder is present in the patch
        string copyFolder = Path.Combine(tempFolder, "copy");
        string[] newFiles = Array.Empty<string>();
        if (Directory.Exists(copyFolder))
        {
            newFiles = Directory.GetFiles(copyFolder, "*.*", SearchOption.AllDirectories);
        }

        var xdeltaCount = maraConfig.FilesInfo.ListOriFiles?.Length ?? 0;
        var totalCount = newFiles.Length + xdeltaCount;
        int currentProgress = 0;

        if (newFiles.Length > 0)
        {
            await Task.Run(() =>
            {
                foreach (var srcFile in newFiles)
                {
                    string relPath = Path.GetRelativePath(copyFolder, srcFile);
                    string destFile = Path.Combine(oriFolder, relPath);
                    string destDir = Path.GetDirectoryName(destFile);

                    if (!string.IsNullOrWhiteSpace(destDir) && !Directory.Exists(destDir))
                        Directory.CreateDirectory(destDir);

                    File.Copy(srcFile, destFile, true);
                    currentProgress++;
                    progress.Report((currentProgress.ToString(), totalCount.ToString()));
                }
            });
        }

        // Step 3: Apply Xdeltas
        var files = maraConfig.FilesInfo;
        for (int i = 0; i < xdeltaCount; i++)
        {
            var excludeFile = false;

            if (files.ListExcludeFiles != null)
                excludeFile = CheckExcludeFile(files.ListOriFiles[i]);

            var oriFile = files.ListOriFiles[i].Replace('\\', Path.DirectorySeparatorChar);
            var xdelta = files.ListXdeltaFiles[i].Replace('\\', Path.DirectorySeparatorChar);
            var outFile = xdelta.Substring(0, xdelta.Length - 7);

            if (excludeFile)
                if (!File.Exists(oriFile))
                    continue;

            var result = await Task.Run(() => ApplyXdelta(oriFile, xdelta, outFile, files.ListMd5Files[i]));

            if (result.Item1 != 0)
                return result;

            currentProgress++;
            progress.Report((currentProgress.ToString(), totalCount.ToString()));
        }

        // Step 4: Deploy target-specific platform files (Win64 or Linux)
        string? targetSubfolder = targetPlatform switch
        {
            TargetPlatform.Win64 => "targets" + Path.DirectorySeparatorChar + "win64",
            TargetPlatform.Linux => "targets" + Path.DirectorySeparatorChar + "linux",
            _ => null
        };

        if (!string.IsNullOrEmpty(targetSubfolder))
        {
            string targetFolder = Path.Combine(tempFolder, targetSubfolder);
            if (Directory.Exists(targetFolder))
            {
                await Task.Run(() =>
                {
                    var targetFiles = Directory.GetFiles(targetFolder, "*.*", SearchOption.AllDirectories);
                    foreach (var srcFile in targetFiles)
                    {
                        string relPath = Path.GetRelativePath(targetFolder, srcFile);
                        string destFile = Path.Combine(oriFolder, relPath);
                        string destDir = Path.GetDirectoryName(destFile);

                        if (!string.IsNullOrWhiteSpace(destDir) && !Directory.Exists(destDir))
                            Directory.CreateDirectory(destDir);

                        File.Copy(srcFile, destFile, true);
                    }
                });

                if (targetPlatform == TargetPlatform.Linux && (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX)))
                {
                    try
                    {
                        string exePath = Path.Combine(oriFolder, "PWAAT.x86_64");
                        if (File.Exists(exePath))
                        {
                            File.SetUnixFileMode(exePath, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute |
                                                         UnixFileMode.GroupRead | UnixFileMode.GroupExecute |
                                                         UnixFileMode.OtherRead | UnixFileMode.OtherExecute);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[PatchProcess] Error setting executable mode: {ex.Message}");
                    }
                }
            }
        }

        DeleteTempFolder();
        return (0, string.Empty);
    }

    private (int, string) ApplyXdelta(string file, string xdelta, string result, string md5)
    {
        var originalFile = $"{oriFolder}{Path.DirectorySeparatorChar}{file}";
        var xdeltaFile = $"{tempFolder}{Path.DirectorySeparatorChar}{xdelta}";
        var outFile = $"{oriFolder}{Path.DirectorySeparatorChar}{result}";

        string oriPath = originalFile + "_ori";
        string fileToPatch;

        // Check the original file first
        if (Md5.CalculateMd5(originalFile) == md5)
        {
            fileToPatch = originalFile;
        }
        else
        {
            // If the original file doesn't match, check the _ori file
            if (File.Exists(oriPath))
            {
                if (Md5.CalculateMd5(oriPath) == md5)
                {
                    fileToPatch = oriPath;
                }
                else
                {
                    return (1, $"The file \"{originalFile}\" (and it's _ori variant) is not equal than the original file.");
                }
            }
            else
            {
                return (1, $"The file \"{originalFile}\" is not equal than the original file.");
            }
        }

        if (fileToPatch != oriPath)
        {
            File.Delete(oriPath);

            if (!File.Exists(oriPath))
            {
                File.Copy(fileToPatch, oriPath);
            }
        }

        var outdir = Path.GetDirectoryName(outFile);
        if (!string.IsNullOrWhiteSpace(outdir) && !Directory.Exists(outdir))
            Directory.CreateDirectory(outdir);

        try
        {
            Xdelta.Apply(File.Open(oriPath, FileMode.Open), File.ReadAllBytes(xdeltaFile), outFile);
        }
        catch (Exception e)
        {
            return (99, $"Error patching the file.\n\n{e.Message}");
        }

        return (0, string.Empty);
    }

    private void GenerateTempFolder()
    {
        tempFolder = Path.GetTempPath() + Path.DirectorySeparatorChar + Path.GetRandomFileName();
        Directory.CreateDirectory(tempFolder);
    }

    private void ExtractPatch()
    {
        Lzma.Unpack(filePath, tempFolder);
        maraConfig = JsonConvert.DeserializeObject<MaraConfig>(File.ReadAllText($"{tempFolder}{Path.DirectorySeparatorChar}data.json"));
    }

    private void DeleteTempFolder()
    {
        Directory.Delete(tempFolder, true);
    }

    public PatchInfo GetInfo()
    {
        return maraConfig.Info;
    }

    private bool CheckExcludeFile(string file)
    {
        foreach (var excludeFile in maraConfig.FilesInfo.ListExcludeFiles)
        {
            if (excludeFile == file)
                return true;
        }

        return false;
    }
}
