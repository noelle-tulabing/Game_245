using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IClickable
{
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
