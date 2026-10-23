using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private const float RotateSpeed = 100f;  // degrees per second
    private const float ZoomSpeed = 10f;     // units per second

    private readonly Vector3 startingPosition = new Vector3(0f, 2f, -2f);

    private Room currentRoom = Room.North;
    private Tween moveTween;
    private Tween rotateTween;

    public UI UI;
    public bool zoomedIn;

    void Start()
    {
        currentRoom = Room.North;
        transform.position = startingPosition;
        transform.rotation = RoomManager.Get(currentRoom).Rotation;
        zoomedIn = false;
    }

    public Room getCurrentRoom() => currentRoom;
    public Quaternion getCurrentRoomRotation() => RoomManager.Get(currentRoom).Rotation;
    public Vector3 getCurrentPosition() => transform.position;
    public Quaternion getCurrentRotation() => transform.rotation;

    // ---------- Rotation ----------

    public void rotateCameraLeft()
    {
        currentRoom = RoomManager.Previous(currentRoom);
        RotateTo(RoomManager.Get(currentRoom).Rotation, RotateSpeed);
    }

    public void rotateCameraRight()
    {
        currentRoom = RoomManager.Next(currentRoom);
        RotateTo(RoomManager.Get(currentRoom).Rotation, RotateSpeed);
    }

    // ---------- Zoom ----------

    public void zoomCameraIn()
    {
        if (transform.position != startingPosition)
            return;

        UI.zoomButton();
        MoveTo(RoomManager.Get(currentRoom).ZoomPosition, ZoomSpeed);
        zoomedIn = true;
    }

    public void zoomOutCamera()
    {
        RoomData room = RoomManager.Get(currentRoom);

        if (IsAtRoomZoomPosition())
        {
            // Zoomed in on a room -> back out to the overview
            MoveTo(startingPosition, ZoomSpeed);
            RotateTo(room.Rotation, RotateSpeed);
            UI.rotateButtons();
            zoomedIn = false;
        }
        else
        {
            // E.g. under the cushion -> back to this room's zoomed-in view
            MoveTo(room.ZoomPosition, ZoomSpeed);
            RotateTo(room.Rotation, RotateSpeed);
        }
    }

    public void focusOnCollectable(CameraFocus collectableData)
    {
        MoveTo(collectableData.cameraViewPosition, 10f);
        RotateTo(collectableData.cameraViewRotation, 100f);
    }

    // ---------- Tween helpers ----------

    void MoveTo(Vector3 target, float unitsPerSecond)
    {
        moveTween?.Kill();

        moveTween = transform
            .DOMove(target, unitsPerSecond)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .SetLink(gameObject)
            .OnComplete(() => moveTween = null);
    }

    void RotateTo(Quaternion target, float degreesPerSecond)
    {
        rotateTween?.Kill();

        float duration = Quaternion.Angle(transform.rotation, target) / degreesPerSecond;

        rotateTween = transform
            .DORotateQuaternion(target, duration)
            .SetEase(Ease.Linear)
            .SetLink(gameObject)
            .OnComplete(() => rotateTween = null);
    }

    bool IsAtRoomZoomPosition()
    {
        foreach (RoomData room in RoomManager.All)
        {
            if (transform.position == room.ZoomPosition)
                return true;
        }
        return false;
    }
}