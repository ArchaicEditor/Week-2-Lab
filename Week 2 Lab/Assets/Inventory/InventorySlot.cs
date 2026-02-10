using UnityEngine;
using System;


[Serializable]
public class InventorySlot
{
    public InventoryItem item;
    public int amount;

    public bool IsFull => amount >= item.maxStack;

    public InventorySlot(InventoryItem item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    
}
