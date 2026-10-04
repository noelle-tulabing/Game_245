using UnityEngine;

public class Collectable : MonoBehaviour, IClickable
{
    public void Start()
    {
        gameObject.SetActive(true);
    }

    
    public void OnClick()
    {
        Inventory.AddItemToEmptyInventorySlot(this);
        gameObject.SetActive(false);
    }
}
