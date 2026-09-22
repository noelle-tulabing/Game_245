using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventorySlot;
    public GameObject[] inventory = new GameObject[9];

    public GameObject[] getInventory()
    {
        return inventory;
    }
	
	public GameObject getItem(int index)
	{
		return inventory[index];
	}

    public void AddItemToEmptyInventorySlot(GameObject add)
    {
        int emptySlot = -1; // assume no empty slots in inventory
        Debug.Log("Adding item to empty slot");
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                emptySlot = i; // an empty slot in inventory found
                inventory[i] = add;
                Debug.Log("Adding item to empty slot: " + i);
                break;
            }
        }
        if (emptySlot == -1)
        {
            return;
        }
        print("Picked up: " + add.transform.name);
    }
    
}
