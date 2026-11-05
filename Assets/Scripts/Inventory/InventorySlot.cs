using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IClickable
{
    [SerializeField] private Collectable item;
    [SerializeField] private int index;
    [SerializeField] private bool selected;

    public Image defaultImage;
    public Sprite defaultSprite;
    public Sprite highlightSprite;

    [SerializeField] private Image itemIcon;
    
    void Start()
    {
        Image firstChildComp = null;
        // Loop through immediate children
        foreach (Transform child in transform)
        {
            firstChildComp = child.GetComponent<Image>();
            itemIcon = firstChildComp;
            itemIcon.enabled = false;
            if (firstChildComp != null) 
            {
                break;
            }
        }        
        selected = false;
    }
    public void setIndex(int index)
    {
        this.index = index;
    }
    public void holdItem(Collectable collectable)
    {
        item = collectable;
        itemIcon.enabled = true;
        itemIcon.sprite = collectable.getIcon();
        
    }
    public Collectable getItem()
    {
        return item;
    }

    public void removeItem()
    {
        itemIcon.enabled = false;
        item = null;
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
