using System;
using UnityEngine;

public class Focus : MonoBehaviour, IClickable
{
    [SerializeField] private CameraFocus cameraFocus;
    [SerializeField] private CameraController cameraController;

    public static event Action OnTvFocus;

    void Start()
    {
        cameraController =  FindFirstObjectByType<CameraController>();
    }

    public void OnClick()
    {
        if (CameraController.zoomedIn)
        {
            cameraController.focusOnCollectable(cameraFocus);
            if (cameraFocus.name == "tv")
            {
                Debug.Log("focusing on tv");
                OnTvFocus?.Invoke();
            }
        }
        else
        {
            Debug.Log("zoom into a room before interacting");
        }
    }
}
