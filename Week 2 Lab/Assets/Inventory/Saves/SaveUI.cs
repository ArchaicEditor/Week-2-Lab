using UnityEngine;

public class SaveUI : MonoBehaviour
{

    public InventoryData inventory;
    public ItemDatabase database;
    public string password;


    public void Save(string password)
    {
        PasswordInventorySystem.Save(inventory, password);
    }

    public void Load(string password)
    {
        bool success =
            PasswordInventorySystem.Load(
                inventory, database, password);

        if (!success)
            Debug.Log("Wrong password!");
    }
}
