using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventorySlot inventorySlot;
    public static InventorySlot[] inventory = new InventorySlot[9];
    [SerializeField] private static int firstOpenSlot;
	private static int slotSelected;
    public Transform InventoryTransfrom;

	void Start()
	{
        for (int i = 0; i < inventory.Length; i++)
        {
            Debug.Log("creating empty slot " + i);
            float xPos = 317f + (i*160f);
            Vector3 spawnPosition = new Vector3(xPos, 80f, 0f);
            inventory[i] = Instantiate(inventorySlot, spawnPosition, Quaternion.identity, InventoryTransfrom);
            inventory[i].setIndex(i);
        }
        firstOpenSlot = 0;
        slotSelected = -1;
	}
    
    public static InventorySlot[] getInventory()
    {
        return inventory;
    }
	
	public static Collectable getItem(int index)
    {
        Debug.Log(index);
		return inventory[index].getItem();
	}

    public static int AddItemToEmptyInventorySlot(Collectable add)
    {
        if (firstOpenSlot == -1)
        {
            return -1;
        }
        else
        {
            inventory[firstOpenSlot].holdItem(add);
        
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].getItem() == null)
                {
                    firstOpenSlot = i;
                    break;
                }
                else
                {
                    firstOpenSlot = -1;
                }
            }

            return firstOpenSlot;
        }
    }

    public static int checkSelected()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].isSelected())
            {
                return i;
            }
        }
        return -1;
    }

    public static void deselect()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].isSelected())
            {
                inventory[i].HighlightInventorySlot();
            }
        }
    }
}
