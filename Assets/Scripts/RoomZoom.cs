using System;
using UnityEngine;

public class RoomZoom : MonoBehaviour, IClickable
{
    public CameraController cameraController;

    public void OnClick()
    {
        cameraController.zoomCameraIn();
    }
}
