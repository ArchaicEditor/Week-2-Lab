using UnityEngine;

[CreateAssetMenu(fileName = "Inventory/Item", menuName = "Scriptable Objects/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public string itemID;   // important for saving
    public string itemName;
    public Sprite icon;
    public bool stackable;
}
