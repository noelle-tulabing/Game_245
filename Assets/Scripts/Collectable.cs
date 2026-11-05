using System.Runtime.CompilerServices;
using UnityEngine;

public class Collectable : MonoBehaviour, IClickable
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private CameraFocus collectableData;
    
    public Sprite icon;
    public void Start()
    {
        gameObject.SetActive(true);
    }

    public Sprite getIcon()
    {
        if (icon == null)
        {
            return null;
        }
        return icon;
    }

    public bool use(Collider item)
    {
        switch (gameObject.name)
        {
            case "key":
                if (item.CompareTag("safe"))
                {
                    item.gameObject.SetActive(false);
                    Inventory.RemoveItemFromInventory(Inventory.checkSelected());
                    Destroy(item.gameObject);
                    Inventory.deselect();
                    // observer thing for first case file 
                        // clear key from inventory
                        // ui case file for progression
                        // open up room(?) 
                    return true;
                }
                break;
            case "screwdriver_poke":
                if (item.CompareTag("screw"))
                {
                    Debug.Log("using screwdriver on screw");
                    item.gameObject.SetActive(false);
                    Debug.Log("screw off");
                    //once all screws off remove screwdriver from inventory?
                    return true;
                }
                break;
            default:
                Debug.Log("cannot use " + gameObject.name + " on " + item.name);
                break;
        }
        return false;
    }
    
    public void OnClick()
    {
        if (cameraController.zoomedIn)
        {
            cameraController.focusOnCollectable(collectableData);
        }
        if (cameraController.getCurrentPosition() == collectableData.cameraViewPosition
            && cameraController.getCurrentRotation() == collectableData.cameraViewRotation)
        {
            Inventory.AddItemToEmptyInventorySlot(this);
        }
    }
}
