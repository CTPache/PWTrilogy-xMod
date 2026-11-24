using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PWTrilogyPatcher.CustomMara;

public static class CapcomCrypto
{
    private static readonly byte[] Key = new byte[] {
        0x35, 0x38, 0x9A, 0xFF, 0xF2, 0x61, 0xB3, 0xE8,
        0x87, 0x22, 0x24, 0x0B, 0x6B, 0x0B, 0x25, 0xC8
    };

    private static readonly byte[] IV = new byte[] {
        0x01, 0x85, 0x40, 0xA5, 0x57, 0xDE, 0x8C, 0x4E,
        0x86, 0xE4, 0x23, 0xE3, 0x3A, 0xB9, 0x77, 0x84
    };

    private static readonly HashSet<string> EncryptedExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".unity3d", ".mdt", ".bin", ".cho", ".mh"
    };

    public static bool TryDecryptFile(string filePath)
    {
        try
        {
            var info = new FileInfo(filePath);
            if (!info.Exists || info.Length == 0) return false;
            if (info.Length % 16 != 0) return false;

            byte[] data = File.ReadAllBytes(filePath);

            // If .unity3d and already starts with UnityFS, skip
            if (data.Length >= 7 &&
                data[0] == 0x55 && data[1] == 0x6E && data[2] == 0x69 &&
                data[3] == 0x74 && data[4] == 0x79 && data[5] == 0x46 && data[6] == 0x53)
            {
                return false;
            }

            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            byte[] decrypted = decryptor.TransformFinalBlock(data, 0, data.Length);

            File.WriteAllBytes(filePath, decrypted);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static void DecryptStreamingAssets(string gameRoot)
    {
        string streamingAssets = Path.Combine(gameRoot, "PWAAT_Data", "StreamingAssets");
        if (!Directory.Exists(streamingAssets))
        {
            streamingAssets = Path.Combine(gameRoot, "StreamingAssets");
            if (!Directory.Exists(streamingAssets)) return;
        }

        var files = Directory.GetFiles(streamingAssets, "*.*", SearchOption.AllDirectories);
        Parallel.ForEach(files, file =>
        {
            string ext = Path.GetExtension(file);
            if (EncryptedExtensions.Contains(ext))
            {
                TryDecryptFile(file);
            }
        });
    }
}
