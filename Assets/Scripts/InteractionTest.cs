using System;
using UnityEngine;

public class InteractionTest : MonoBehaviour, IClickable
{
    public PlayerInteraction player;
    public CameraController cameraController;

    public void OnClick()
    {
        print(gameObject.name + " has been clicked");
        cameraController.zoomCameraIn();
        player.OnClick();
    }
}
