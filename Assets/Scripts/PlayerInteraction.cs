using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IClickable
{
    //private Collectable collectable;

    void Start()
    {
        //collectable = null;
    }
    
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
    }
}
