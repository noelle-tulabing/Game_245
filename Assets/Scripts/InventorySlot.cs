using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IClickable
{
    [SerializeField] private int index;
    //[SerializeField] private Inventory inventory;
    [SerializeField] private Collectable item;
    
    [SerializeField] bool selected;
    public Image defaultImage; // Drag your UI Image here
    public Sprite defaultSprite; // First image
    public Sprite highlightSprite; // Second image

    void Start()
    {
        //defaultImage = GetComponent<Image>();
        defaultImage.sprite = defaultSprite;
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
