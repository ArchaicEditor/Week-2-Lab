using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float moveSpeed = 5f;
    public InventoryData inventory;


    void Start()
    {
        
    }

    
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    public void Pickup(InventoryItem item)
    {
        inventory.AddItem(item, 1);
    }

    public void UseItem(InventoryItem item)
    {
        inventory.RemoveItem(item, 1);
    }




}
