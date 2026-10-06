using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IClickable
{
    public Collectable collectable;

    private void use(Collider item)
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
        if (Inventory.getItem(index) == collectable)
        {
            Destroy(collectable.gameObject);
            Debug.Log("you win!");
        }
    }
}
