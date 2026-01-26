using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InventoryData inventory;
    public ItemDatabase itemDatabase;

    [TextArea] public string publicKey;
    [TextArea] public string privateKey;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventorySaveSystem.Load(inventory, itemDatabase, privateKey);
        
    }

    // Update is called once per frame
    void OnApplicationQuit()
    {
        InventorySaveSystem.Save(inventory, publicKey);
        inventory.Clear();
        //Debug.Log(Application.persistentDataPath);
    }

    
}
