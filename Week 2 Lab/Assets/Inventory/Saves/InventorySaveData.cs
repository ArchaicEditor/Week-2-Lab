using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventorySaveData
{
    public List<string> itemIDs = new();
    public List<int> amounts = new();
}
