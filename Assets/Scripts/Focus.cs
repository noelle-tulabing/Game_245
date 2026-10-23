using UnityEngine;

public class Focus : MonoBehaviour, IClickable
{
    [SerializeField] private CameraFocus cameraFocus;
    [SerializeField] private CameraController cameraController;

    void Start()
    {
        cameraController =  FindObjectOfType<CameraController>();
    }

    public void OnClick()
    {
        if (cameraController.zoomedIn)
        {
            Debug.Log("Focusing on specific item/area");
            cameraController.focusOnCollectable(cameraFocus);
        }
        else
        {
            Debug.Log("zoom into a room before interacting");
        }
    }
}
