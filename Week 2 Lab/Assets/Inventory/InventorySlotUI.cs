using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI stackText;

    public void SetSlot(InventorySlot slot)
    {
        itemNameText.text = slot.item.itemName;
        quantityText.text = slot.amount.ToString();
        stackText.text = $"{slot.amount} / {slot.item.maxStack}";
    }
}
