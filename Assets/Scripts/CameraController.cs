using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private const float RotateSpeed = 100f;  // degrees per second
    private const float ZoomSpeed = 10f;     // units per second

    private readonly Vector3 startingPosition = new Vector3(0f, 2f, -2f);

    // Index order must match: 0 = north, 1 = east, 2 = south, 3 = west
    private readonly Quaternion[] rooms =
    {
        Quaternion.Euler(0f, 0f, 0f), // north room
        Quaternion.Euler(0f, 90f, 0f), // east room
        Quaternion.Euler(0f, 180f, 0f), // south room
        Quaternion.Euler(0f, 270f, 0f) // west room
    };

    private readonly Vector3[] roomZoomPositions =
    {
        new Vector3(0f, 2f, 3f), // north room zoom
        new Vector3(5f, 2f, -2f), // east room zoom
        new Vector3(0f, 2f, -7f), // south room zoom
        new Vector3(-5f, 2f, -2f) // west room zoom
    };

    private int currentRoom;
    private Tween moveTween;
    private Tween rotateTween;

    public UI UI;

    void Start()
    {
        transform.position = startingPosition;
        transform.rotation = rooms[0];
        currentRoom = 0;
    }

    public Quaternion getCurrentRoom() => rooms[currentRoom];
    public Vector3 getCurrentPosition() => transform.position;
    public Quaternion getCurrentRotation() => transform.rotation;

    // ---------- Rotation ----------

    public void rotateCameraLeft()
    {
        currentRoom = (currentRoom + 3) % 4;   // -1 with wraparound
        RotateTo(rooms[currentRoom], RotateSpeed);
    }

    public void rotateCameraRight()
    {
        currentRoom = (currentRoom + 1) % 4;
        RotateTo(rooms[currentRoom], RotateSpeed);
    }

    // ---------- Zoom ----------

    public void zoomCameraIn()
    {
        if (transform.position != startingPosition)
            return;

        UI.zoomButton();
        MoveTo(roomZoomPositions[currentRoom], ZoomSpeed);
    }

    public void zoomOutCamera()
    {
        if (IsAtRoomZoomPosition())
        {
            // Zoomed in on a room -> back out to the overview
            MoveTo(startingPosition, ZoomSpeed);
            RotateTo(rooms[currentRoom], RotateSpeed);
            UI.rotateButtons();
        }
        else
        {
            // E.g. under the cushion -> back to this room's zoomed-in view
            MoveTo(roomZoomPositions[currentRoom], ZoomSpeed);
            RotateTo(rooms[currentRoom], RotateSpeed);
        }
    }

    public void checkUnderCushion(Cushion cushionData)
    {
        // Only move if we're zoomed in on this cushion's room
        if (transform.position != cushionData.cameraRoomZoom)
            return;

        MoveTo(cushionData.cameraViewPosition, 10f);
        RotateTo(cushionData.cameraViewRotation, 100f);
    }

    public void focusOnCollectable(CollectableData collectableData)
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

        // Duration from angle keeps the speed in degrees/sec
        float duration = Quaternion.Angle(transform.rotation, target) / degreesPerSecond;

        rotateTween = transform
            .DORotateQuaternion(target, duration)
            .SetEase(Ease.Linear)
            .SetLink(gameObject)
            .OnComplete(() => rotateTween = null);
    }

    bool IsAtRoomZoomPosition()
    {
        foreach (Vector3 pos in roomZoomPositions)
        {
            if (transform.position == pos)
                return true;
        }
        return false;
    }
}