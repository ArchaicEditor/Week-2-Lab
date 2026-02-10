using UnityEngine;

public class SaveUI : MonoBehaviour
{

    public InventoryData inventor;
    public ItemDatabase database;
    public string password;


    public void Save(string password)
    {
        PasswordInventorySystem.Save(inventor, password);

        Debug.Log("Saved");
    }

    public void Load(string password)
    {
        bool success =
            PasswordInventorySystem.Load(
                inventor, database, password);

        if (!success)
            Debug.Log("Wrong password!");
    }

    

}
