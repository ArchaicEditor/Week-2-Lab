using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(fileName = "Inventory/InventoryData", menuName = "Scriptable Objects/InventoryData")]
public class InventoryData : ScriptableObject
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    public void AddItem(InventoryItem item, int amount = 1)
    {
        if (item.stackable)
        {
            InventorySlot slot = slots.Find(s => s.item == item);
            if (slot != null)
            {
                slot.amount += amount;
                return;
            }
        }

        slots.Add(new InventorySlot(item, amount));
    }

    public void RemoveItem(InventoryItem item, int amount = 1)
    {
        InventorySlot slot = slots.Find(s => s.item == item);
        if (slot == null) return;

        slot.amount -= amount;
        if (slot.amount <= 0)
            slots.Remove(slot);
    }

    public void Clear()
    {
        slots.Clear();
    }

    public InventorySaveData ToSaveData()
    {
        InventorySaveData data = new InventorySaveData();

        foreach (var slot in slots)
        {
            data.itemIDs.Add(slot.item.itemID);
            data.amounts.Add(slot.amount);
        }

        return data;
    }

    public void LoadFromSaveData(InventorySaveData data,Dictionary<string, InventoryItem> itemLookup)
    {
        slots.Clear();

        for (int i = 0; i < data.itemIDs.Count; i++)
        {
            if (itemLookup.TryGetValue(data.itemIDs[i], out InventoryItem item))
            {
                slots.Add(new InventorySlot(item, data.amounts[i]));
            }
        }
    }

    
}
