using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Collectable : MonoBehaviour, IClickable
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private CameraFocus collectableData;
    public static event Action OnKeyUsed;
    public static event Action OnScrewdriverUsed;
    public static event Action OnUnscrewedScrew;
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
                    OnKeyUsed?.Invoke();
                    Inventory.RemoveItemFromInventory(Inventory.checkSelected());
                    Destroy(item.gameObject);
                    Inventory.deselect();
                    return true;
                }
                break;
            case "screwdriver_poke":
                if (item.CompareTag("screw"))
                {
                    OnScrewdriverUsed?.Invoke();
                    item.gameObject.SetActive(false);
                    OnUnscrewedScrew?.Invoke();
                    Debug.Log("player has unscrewed " + Player.GetScrewsUnscrewed() + " screws");
                    if (Player.GetScrewsUnscrewed() == 16) // idk why 
                    {
                        Inventory.RemoveItemFromInventory(Inventory.checkSelected());
                    }
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
        if (CameraController.zoomedIn)
        {
            cameraController.focusOnCollectable(collectableData);
        }
        if (CameraController.getCurrentPosition() == collectableData.cameraViewPosition
            && CameraController.getCurrentRotation() == collectableData.cameraViewRotation)
        {
            Inventory.AddItemToEmptyInventorySlot(this);
        }
    }
}
