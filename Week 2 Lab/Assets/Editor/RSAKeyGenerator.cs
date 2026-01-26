using UnityEngine;
using UnityEditor;
using System.Security.Cryptography;

public class RSAKeyGenerator
{
    [MenuItem("Tools/Security/Generate RSA Keys")]
    public static void GenerateKeys()
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
        {
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            Debug.Log("PUBLIC KEY:\n" + publicKey);
            Debug.Log("PRIVATE KEY:\n" + privateKey);
        }
    }
}
