using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class AESEncryption
{
    public static byte[] Encrypt(string plainText, byte[] key, byte[] iv)
    {
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        var encryptor = aes.CreateEncryptor();
        byte[] bytes = Encoding.UTF8.GetBytes(plainText);

        return encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
    }

    public static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
    {
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        var decryptor = aes.CreateDecryptor();
        byte[] decrypted = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);

        return Encoding.UTF8.GetString(decrypted);
    }
}
