using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace PWTrilogyPatcher.CustomMara;

public static class SteamUtils
{
    // https://github.com/TraduSquare/Mara/blob/b3518f380786b1cd5a14e7b60168c42bdce1623c/Mara.Lib/Common/Steam/SteamUtils.cs#L34
    public static string GetSteamPath()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var paths = new[] { ".steam", ".steam/steam", ".steam/root", ".local/share/Steam",
                ".var/app/com.valvesoftware.Steam/.steam", ".var/app/com.valvesoftware.Steam/.steam/steam", ".var/app/com.valvesoftware.Steam/.steam/root"}; // flatpak

            var steamPaths = paths
                .Select(path => Path.Join(home, path))
                .Where(steamPath => Directory.Exists(Path.Join(steamPath, "appcache")));

            if (steamPaths.Any())
            {
                return steamPaths.First().Replace('\\', Path.DirectorySeparatorChar);
            }
            else
            {
                return string.Empty;
            }
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam") ??
                      RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                          .OpenSubKey("SOFTWARE\\Valve\\Steam");

            if (key != null && key.GetValue("SteamPath") is string steamPath)
            {
                return steamPath.Replace('/', Path.DirectorySeparatorChar);
            }
            else
            {
                return string.Empty;
            }
        }

        throw new PlatformNotSupportedException();
    }

    // https://github.com/TraduSquare/Mara/blob/b3518f380786b1cd5a14e7b60168c42bdce1623c/Mara.Lib/Common/Steam/Api/LibraryFolders.cs#L11
    // https://github.com/TraduSquare/Mara/blob/b3518f380786b1cd5a14e7b60168c42bdce1623c/Mara.Lib/Common/Steam/SteamUtils.cs#L77
    public static string GetSteamGamePath(string steamPath)
    {
        var libraryfolders = Path.Combine(steamPath, "config", "libraryfolders.vdf");

        if (File.Exists(libraryfolders))
        {
            var txt = File.ReadAllLines(libraryfolders);

            foreach (var s in txt)
            {
                if (s.Contains("\"path\""))
                {
                    var library = s.Replace("		\"path\"		\"", "").Replace("\"", "").Replace("\\\\", "\\").Replace('\\', Path.DirectorySeparatorChar);

                    var tmpPath = Path.Combine(library, "steamapps", "common", "Phoenix Wright Ace Attorney Trilogy");
                    if (Directory.Exists(tmpPath))
                    {
                        return tmpPath;
                    }
                }
            }
        }

        return string.Empty;
    }

    public static void SetSteamLaunchOptions(string steamPath, string appId, string options)
    {
        try
        {
            var userdataDir = Path.Combine(steamPath, "userdata");
            if (!Directory.Exists(userdataDir)) return;

            foreach (var userDir in Directory.GetDirectories(userdataDir))
            {
                var localConfig = Path.Combine(userDir, "config", "localconfig.vdf");
                if (!File.Exists(localConfig)) continue;

                var content = File.ReadAllText(localConfig);
                var updated = UpdateVdfLaunchOptions(content, appId, options);
                if (updated != content)
                {
                    File.Copy(localConfig, localConfig + ".bak", true);
                    File.WriteAllText(localConfig, updated);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SteamUtils] Error setting launch options: {ex.Message}");
        }
    }

    public static void ClearSteamLaunchOptions(string steamPath, string appId)
    {
        try
        {
            var userdataDir = Path.Combine(steamPath, "userdata");
            if (!Directory.Exists(userdataDir)) return;

            foreach (var userDir in Directory.GetDirectories(userdataDir))
            {
                var localConfig = Path.Combine(userDir, "config", "localconfig.vdf");
                if (!File.Exists(localConfig)) continue;

                var content = File.ReadAllText(localConfig);
                var updated = UpdateVdfLaunchOptions(content, appId, null);
                if (updated != content)
                {
                    File.Copy(localConfig, localConfig + ".bak", true);
                    File.WriteAllText(localConfig, updated);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SteamUtils] Error clearing launch options: {ex.Message}");
        }
    }

    private static string UpdateVdfLaunchOptions(string text, string appId, string? newOpt)
    {
        var lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        bool inApp = false;
        bool optFound = false;
        int braceDepth = 0;
        var newLines = new System.Collections.Generic.List<string>();

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string stripped = line.Trim();

            if (!inApp)
            {
                if (stripped == $"\"{appId}\"")
                {
                    inApp = true;
                    newLines.Add(line);
                    continue;
                }
            }
            else
            {
                if (stripped == "{")
                {
                    braceDepth++;
                    newLines.Add(line);
                    continue;
                }
                else if (stripped == "}")
                {
                    braceDepth--;
                    if (braceDepth <= 0)
                    {
                        if (!optFound && !string.IsNullOrEmpty(newOpt))
                        {
                            newLines.Add($"\t\t\t\t\t\t\"LaunchOptions\"\t\t\"{newOpt}\"");
                        }
                        inApp = false;
                    }
                    newLines.Add(line);
                    continue;
                }

                if (stripped.StartsWith("\"LaunchOptions\""))
                {
                    optFound = true;
                    if (!string.IsNullOrEmpty(newOpt))
                    {
                        newLines.Add($"\t\t\t\t\t\t\"LaunchOptions\"\t\t\"{newOpt}\"");
                    }
                    continue;
                }
            }

            newLines.Add(line);
        }

        return string.Join(Environment.NewLine, newLines);
    }
}
