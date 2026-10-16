using UnityEngine;

public class Collectable : MonoBehaviour, IClickable
{
    public Sprite icon;
    public void Start()
    {
        gameObject.SetActive(true);
    }

    public Sprite getIcon()
    {
        return icon;
    }
    
    public void OnClick()
    {
        Inventory.AddItemToEmptyInventorySlot(this);
    }
}
