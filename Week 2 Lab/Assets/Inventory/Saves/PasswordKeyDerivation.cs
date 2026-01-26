 using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class PasswordKeyDerivation
{
    public static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }

    public static byte[] DeriveKey(string password, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            salt,
            100_000,              // iterations (important)
            HashAlgorithmName.SHA256);

        return pbkdf2.GetBytes(32); // 256-bit AES key
    }
}
