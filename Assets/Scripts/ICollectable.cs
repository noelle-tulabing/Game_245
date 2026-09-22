using UnityEngine;

public interface ICollectable
{
    //public GameObject[] inventory;
    
	public void AddItemToEmptyInventorySlot(GameObject add, GameObject[] inventory)
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
        // add TileBase in correct inventory slot in game...
        if (emptySlot == -1)
        {
            return;
        }
        Debug.Log("Picked up: " + add.transform.name);
    }
}
