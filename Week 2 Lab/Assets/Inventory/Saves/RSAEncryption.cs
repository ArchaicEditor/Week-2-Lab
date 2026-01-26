using System.Security.Cryptography;
using UnityEngine;

public class RSAEncryption
{
    public static byte[] Encrypt(byte[] data, string publicKey)
    {
        using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        rsa.FromXmlString(publicKey);
        return rsa.Encrypt(data, false);
    }

    public static byte[] Decrypt(byte[] data, string privateKey)
    {
        using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        rsa.FromXmlString(privateKey);
        return rsa.Decrypt(data, false);
    }
}
