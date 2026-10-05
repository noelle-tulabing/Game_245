using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IClickable
{
    [SerializeField] private int index;
    [SerializeField] private Collectable item;
    
    [SerializeField] bool selected;
    public Image defaultImage;
    public Sprite defaultSprite;
    public Sprite highlightSprite;

    void Start()
    {
        //defaultImage.sprite = defaultSprite;
        selected = false;
    }
    public void setIndex(int index)
    {
        this.index = index;
    }
    public void holdItem(Collectable collectable)
    {
        item = collectable;
    }
    public Collectable getItem()
    {
        return item;
    }

    public bool isSelected()
    {
        return selected;
    }
    
    public void HighlightInventorySlot()
    {
        if (!selected) 
        {
            defaultImage.sprite = highlightSprite;
        }
        else 
        {
            defaultImage.sprite = defaultSprite;
        }
        selected = !selected;
    }

    public void OnClick()
    {
        if (Inventory.checkSelected() == -1 || Inventory.checkSelected() == index)
        {
            HighlightInventorySlot();
        }
        else
        {
            Inventory.deselect();
            HighlightInventorySlot();
        }
        if (Inventory.getItem(index) != null)
        {
           Debug.Log(item.gameObject.name + " at index " + index);
        }
        else
        {
            Debug.Log("No item found at index " + index);
        }
    }
}
