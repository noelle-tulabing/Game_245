using System;
using UnityEngine;

public class RoomZoom : MonoBehaviour, IClickable
{
    public PlayerInteraction player;
    public CameraController cameraController;

    public void OnClick()
    {
        print(gameObject.name + " has been clicked");
        switch (gameObject.tag) // check if player is zoomed into the room before allowing interactions
        {
            case "NorthRoom":
                break;
            case "SouthRoom":
                break;
            case "EastRoom":
                break;
            case "WestRoom":
                break;
            default:
                break;
        }
        cameraController.zoomCameraIn();
        player.OnClick();
    }
}
