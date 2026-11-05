using System;
using UnityEngine;

public class RoomZoom : MonoBehaviour, IClickable
{
    public CameraController cameraController;

    public void OnClick()
    {
        print(gameObject.name + " has been clicked");
        cameraController.zoomCameraIn();
    }
}
