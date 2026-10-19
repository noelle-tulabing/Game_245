using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IClickable
{
    public Collectable collectable;

    private static void use(Collider item) // ex: item1.use(item2)
    {
        
    }

    public void OnClick()
    {
        if (Inventory.checkSelected() == -1)
        {
            return;
        }
        int index = Inventory.checkSelected();
        if (index == -1)
        {
            return;
        }
        Debug.Log("player has selected index: " + index);
        Debug.Log("checking if item: " + Inventory.getItem(index).name + " against " + collectable.name);
        if (Inventory.getItem(index) == collectable) // breaks if selected collectable is the collectable
                                                     // (does not check what the item is being used on)
        {
            Inventory.RemoveItemFromInventory(Inventory.checkSelected());
            //Destroy(collectable.gameObject);
            Debug.Log("you win!");
        }
    }
}
