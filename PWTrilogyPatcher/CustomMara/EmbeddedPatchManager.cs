using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PWTrilogyPatcher.CustomMara;

public static class EmbeddedPatchManager
{
    private const string ResourceName = "PWTrilogyPatcher.Resources.patch_payload.bin";
    private static readonly byte[] MagicBytes = Encoding.ASCII.GetBytes("PWAATENC");
    private static readonly byte[] AuthTagData = Encoding.UTF8.GetBytes("PWAAT_PAYLOAD_AUTH");
    private const int HeaderSize = 60; // 8 (magic) + 4 (version) + 16 (IV) + 32 (AuthToken)

    public static bool HasEmbeddedPayload()
    {
        var assembly = typeof(EmbeddedPatchManager).Assembly;
        using var stream = assembly.GetManifestResourceStream(ResourceName);
        return stream != null;
    }

    public static bool TryDeriveKey(string gamePath, out byte[]? key, out string? validatedFile)
    {
        key = null;
        validatedFile = null;

        // Search candidates in priority order
        string[] candidates = new string[]
        {
            Path.Combine(gamePath, "PWAAT.exe"),
            Path.Combine(gamePath, "PWAAT.exe_ori"),
            Path.Combine(gamePath, "Content", "PWAAT.exe"),
            Path.Combine(gamePath, "Content", "PWAAT.exe_ori")
        };

        foreach (var candidate in candidates)
        {
            if (!File.Exists(candidate)) continue;

            try
            {
                byte[] candidateKey = ComputeSha256(candidate);
                if (ValidateCandidateKey(candidateKey))
                {
                    key = candidateKey;
                    validatedFile = candidate;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EmbeddedPatch] Error checking candidate {candidate}: {ex.Message}");
            }
        }

        return false;
    }

    public static bool ValidateCandidateKey(byte[] candidateKey)
    {
        var assembly = typeof(EmbeddedPatchManager).Assembly;
        using var stream = assembly.GetManifestResourceStream(ResourceName);
        if (stream == null) return false;

        byte[] header = new byte[HeaderSize];
        int read = stream.Read(header, 0, HeaderSize);
        if (read < HeaderSize) return false;

        // Check magic
        for (int i = 0; i < MagicBytes.Length; i++)
        {
            if (header[i] != MagicBytes[i]) return false;
        }

        // AuthToken is bytes 28..59 (32 bytes)
        byte[] storedAuthToken = new byte[32];
        Buffer.BlockCopy(header, 28, storedAuthToken, 0, 32);

        using var hmac = new HMACSHA256(candidateKey);
        byte[] computedAuthToken = hmac.ComputeHash(AuthTagData);

        return CryptographicOperations.FixedTimeEquals(computedAuthToken, storedAuthToken);
    }

    public static async Task DecryptPayloadAsync(byte[] key, string outputZipPath, IProgress<(string, string)>? progress = null)
    {
        var assembly = typeof(EmbeddedPatchManager).Assembly;
        using var stream = assembly.GetManifestResourceStream(ResourceName);
        if (stream == null)
        {
            throw new InvalidOperationException("No se encontró el recurso del parche embebido.");
        }

        byte[] header = new byte[HeaderSize];
        int read = await stream.ReadAsync(header.AsMemory(0, HeaderSize));
        if (read < HeaderSize)
        {
            throw new InvalidDataException("Cabecera del payload embebido truncada.");
        }

        // Validate magic
        for (int i = 0; i < MagicBytes.Length; i++)
        {
            if (header[i] != MagicBytes[i])
            {
                throw new InvalidDataException("Firma mágica del payload embebido no válida.");
            }
        }

        // Extract IV (bytes 12..27, 16 bytes)
        byte[] iv = new byte[16];
        Buffer.BlockCopy(header, 12, iv, 0, 16);

        // Validate key auth token (bytes 28..59, 32 bytes)
        byte[] storedAuthToken = new byte[32];
        Buffer.BlockCopy(header, 28, storedAuthToken, 0, 32);

        using (var hmac = new HMACSHA256(key))
        {
            byte[] computedAuthToken = hmac.ComputeHash(AuthTagData);
            if (!CryptographicOperations.FixedTimeEquals(computedAuthToken, storedAuthToken))
            {
                throw new UnauthorizedAccessException("La clave derivada no coincide con la firma del parche.");
            }
        }

        long totalEncryptedBytes = stream.Length - HeaderSize;
        long totalMB = totalEncryptedBytes / (1024 * 1024);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var decryptor = aes.CreateDecryptor();
        using var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read);
        using var outputStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: true);

        byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
        long totalRead = 0;
        int bytesRead;

        while ((bytesRead = await cryptoStream.ReadAsync(buffer.AsMemory(0, buffer.Length))) > 0)
        {
            await outputStream.WriteAsync(buffer.AsMemory(0, bytesRead));
            totalRead += bytesRead;
            long currentMB = totalRead / (1024 * 1024);
            progress?.Report((currentMB.ToString(), totalMB.ToString()));
        }
    }

    private static byte[] ComputeSha256(string filePath)
    {
        using var sha = SHA256.Create();
        using var fs = File.OpenRead(filePath);
        return sha.ComputeHash(fs);
    }
}
