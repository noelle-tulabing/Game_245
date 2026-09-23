using UnityEngine;
using UnityEngine.UI;

// collectable class ?
public class InventorySlot : MonoBehaviour, IClickable
{
    public int index;
    public Inventory inventory;

    private bool selected;

    void Start()
    {
        
    }

    public void HighlightInventorySlot()
    {
        if (!selected) 
        {
            // highlight inventory slot
        }
        else // already selected & clicked again
        {
            // return to default image
        }
        selected = !selected;
    }

    public void OnClick()
    {
        HighlightInventorySlot();
        if (inventory.getItem(index) != null)
        {
           Debug.Log(inventory.getItem(index) + " at index " + index);
        }
        else
        {
            Debug.Log("No item found at index " + index);
        }
    }
}
