using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventory/ItemDatabase", menuName = "Scriptable Objects/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<InventoryItem> items;

    private Dictionary<string, InventoryItem> lookup;

    public Dictionary<string, InventoryItem> BuildLookup()
    {
        lookup = new Dictionary<string, InventoryItem>();

        foreach (var item in items)
        {
            lookup[item.itemID] = item;
        }

        return lookup;
    }
}
