using System;
using UnityEngine;

public class RoomZoom : MonoBehaviour, IClickable
{
    public CameraController cameraController;
    private Collider RoomCollider;

    void Start()
    {
        RoomCollider = GetComponent<Collider>();
    }

    public void OnClick()
    {
        cameraController.zoomCameraIn();
        //RoomCollider.gameObject.SetActive(false);
        RoomCollider.enabled = false;
    }

    private void OnEnable()
    {
        CameraController.OnRoomZoomOut += enableRoomCollider;
    }

    private void OnDisable()
    {
        CameraController.OnRoomZoomOut -= enableRoomCollider;
    }

    private void enableRoomCollider()
    {
        RoomCollider.gameObject.SetActive(true);
        RoomCollider.enabled = true;
    }
}
