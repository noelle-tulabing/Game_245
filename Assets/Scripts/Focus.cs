using System;
using UnityEngine;

public class Focus : MonoBehaviour, IClickable
{
    [SerializeField] private CameraFocus cameraFocus;
    [SerializeField] private CameraController cameraController;

    

    void Start()
    {
        cameraController =  FindFirstObjectByType<CameraController>();
    }

    public void OnClick()
    {
        if (CameraController.zoomedIn)
        {
            if (gameObject.GetComponent<Collectable>() == null)
            {
                   
            }
            cameraController.focusOnCollectable(cameraFocus);
        }
        else
        {
            Debug.Log("zoom into a room before interacting");
        }
    }
}
