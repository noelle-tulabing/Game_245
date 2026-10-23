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
        return icon;
    }

    public bool use(Collider item)
    {
        switch (gameObject.name)
        {
            case "screwdriver_poke":
                if (item.CompareTag("screw"))
                {
                    Debug.Log("using screwdriver on screw");
                    item.gameObject.SetActive(false);
                    Debug.Log("screw off");
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
            Debug.Log("player can see a collectable");
            cameraController.focusOnCollectable(collectableData);
            Debug.Log("player has focused on collectable");
        }
        if (cameraController.getCurrentPosition() == collectableData.cameraViewPosition
            && cameraController.getCurrentRotation() == collectableData.cameraViewRotation)
        {
            Debug.Log("adding item " + this.name + " to inventory");
            Inventory.AddItemToEmptyInventorySlot(this);
            Debug.Log(this.name + " has been added to inventory");
        }
    }
}
