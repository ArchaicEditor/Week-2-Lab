using UnityEngine;
using System.IO;
using System.Security.Cryptography;

public class InventorySaveSystem
{
    private static string SavePath =>
       Path.Combine(Application.persistentDataPath, "inventory.dat");

    public static void Save(InventoryData inventory, string publicKey)
    {
        InventorySaveData saveData = inventory.ToSaveData();
        string json = JsonUtility.ToJson(saveData);

        using Aes aes = Aes.Create();

        byte[] encryptedInventory =
            AESEncryption.Encrypt(json, aes.Key, aes.IV);

        byte[] encryptedKey =
            RSAEncryption.Encrypt(aes.Key, publicKey);

        using BinaryWriter writer = new BinaryWriter(File.Open(SavePath, FileMode.Create));
        {
            writer.Write(encryptedKey.Length);
            writer.Write(encryptedKey);

            writer.Write(aes.IV.Length);
            writer.Write(aes.IV);

            writer.Write(encryptedInventory.Length);
            writer.Write(encryptedInventory);
        }
    }

    public static void Load(
        InventoryData inventory,
        ItemDatabase database,
        string privateKey)
    {
        if (!File.Exists(SavePath))
            return;

        using BinaryReader reader = new BinaryReader(File.Open(SavePath, FileMode.Open));
        {
            byte[] encryptedKey = reader.ReadBytes(reader.ReadInt32());
            byte[] iv = reader.ReadBytes(reader.ReadInt32());
            byte[] encryptedInventory = reader.ReadBytes(reader.ReadInt32());

            byte[] aesKey =
                RSAEncryption.Decrypt(encryptedKey, privateKey);

            string json =
                AESEncryption.Decrypt(encryptedInventory, aesKey, iv);

            InventorySaveData saveData =
                JsonUtility.FromJson<InventorySaveData>(json);

            inventory.LoadFromSaveData(
                saveData,
                database.BuildLookup());
        }
    }
}
