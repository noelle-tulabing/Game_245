using UnityEngine;

public class Collectable : MonoBehaviour, IClickable
{
    public Inventory playerInventory;

    public void Start()
    {
        gameObject.SetActive(true);
    }
    
    public void OnClick()
    {
        playerInventory.AddItemToEmptyInventorySlot(gameObject);
        gameObject.SetActive(false);
    }
}
