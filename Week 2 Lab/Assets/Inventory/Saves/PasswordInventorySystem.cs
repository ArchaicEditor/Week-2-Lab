using UnityEngine;
using System.IO;
using System.Security.Cryptography;

public class PasswordInventorySystem
{
    private static string SavePath =>
        Path.Combine(Application.persistentDataPath, "inventory.dat");

    public static void Save(
        InventoryData inventory,
        string password)
    {
        InventorySaveData saveData = inventory.ToSaveData();
        string json = JsonUtility.ToJson(saveData);

        byte[] salt = PasswordKeyDerivation.GenerateSalt();
        byte[] key = PasswordKeyDerivation.DeriveKey(password, salt);

        using Aes aes = Aes.Create();
        aes.Key = key;

        byte[] encryptedData =
            AESEncryption.Encrypt(json, aes.Key, aes.IV);

        using BinaryWriter writer =
            new BinaryWriter(File.Open(SavePath, FileMode.Create));
        {
            writer.Write(salt.Length);
            writer.Write(salt);

            writer.Write(aes.IV.Length);
            writer.Write(aes.IV);

            writer.Write(encryptedData.Length);
            writer.Write(encryptedData);
        }
    }

    public static bool Load(InventoryData inventory, ItemDatabase database, string password)
    {
        if (!File.Exists(SavePath))
            return false;

        try
        {
            using BinaryReader reader =
                new BinaryReader(File.Open(SavePath, FileMode.Open));
        {
                byte[] salt = reader.ReadBytes(reader.ReadInt32());
                byte[] iv = reader.ReadBytes(reader.ReadInt32());
                byte[] encryptedData = reader.ReadBytes(reader.ReadInt32());

                byte[] key =
                    PasswordKeyDerivation.DeriveKey(password, salt);

                string json =
                    AESEncryption.Decrypt(encryptedData, key, iv);

                InventorySaveData saveData =
                    JsonUtility.FromJson<InventorySaveData>(json);

                inventory.LoadFromSaveData(
                    saveData,
                    database.BuildLookup());

                return true; // password correct
            }
        }
        catch
        {
            return false; // wrong password or tampered file
        }
    }
}
