using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public InventoryData inventory;
    public InventorySlotUI slotPrefab;
    public Transform contentParent;


    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        foreach (var slot in inventory.slots)
        {
            InventorySlotUI uiSlot = Instantiate(slotPrefab, contentParent);

            uiSlot.SetSlot(slot);
        }
    }

    
}
