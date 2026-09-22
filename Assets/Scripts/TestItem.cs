using UnityEngine;

public class TestItem : MonoBehaviour, IClickable
{
    public Inventory playerInventory;
	public GameObject item;

    public void Start()
    {
        item.SetActive(true);
    }
    
    public void OnClick()
    {
        playerInventory.AddItemToEmptyInventorySlot(item);
        item.SetActive(false);
    }
}
