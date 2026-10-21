using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IClickable
{
    void Start()
    {
        //collectable = null;
    }
    
    // private static void use(Collider item) // ex: item1.use(item2)
    // {
    //     Collectable useItem = Inventory.getItem(Inventory.checkSelected());
    //     switch (useItem.name)
    //     {
    //         case "screwdriver_poke":
    //             if (item.transform.gameObject.CompareTag("screw"))
    //             {
    //                 Destroy(item.transform.gameObject);
    //             }
    //             break;
    //         case "book_2":
    //             if (item.transform.gameObject.CompareTag("cushion"))
    //             {
    //                 CushionInteraction cushion = item.transform.gameObject.GetComponent<CushionInteraction>();
    //                 cushion.OnClick();
    //             }
    //             break;
    //         default:
    //             Debug.Log("cannot use " + item.name + " on " + item.transform.name);
    //             break;
    //     }
    // }

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
