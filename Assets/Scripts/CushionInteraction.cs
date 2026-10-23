using UnityEngine;
using DG.Tweening;

public class CushionInteraction : MonoBehaviour, IClickable
{
    public CameraController cameraController;
    [SerializeField] private CameraFocus cameraFocus;
    [SerializeField] private Cushion cushionData;
    private float speed = 5f;
    private Tween moveTween;

    void Start()
    {
        transform.position = cushionData.startingPosition;
    }

    void Update()
    {
        if (transform.position != cushionData.startingPosition &&
            cameraController.getCurrentPosition() != cameraFocus.cameraViewPosition)
        {
            moveCushionDown();
        }
    }

    private void moveCushionDown()
    {
        moveTo(cushionData.startingPosition);
    }

    public void OnClick()
    {
        if (cameraController.getCurrentRoom() == Room.North)
        {
            if (Inventory.getItem(Inventory.checkSelected()) == null || Inventory.getItem(Inventory.checkSelected()).name != "book_2")
            {
                Debug.Log("missing an item");
                return;
            }
        }
        moveCushion();
    }

    private void moveCushion()
    {
        if (cameraController.zoomedIn && cameraController.getCurrentPosition() != cameraFocus.cameraViewPosition)
        {
            Debug.Log("cannot move cushion");
            return;
        }
        moveTo(transform.position != cushionData.startingPosition ? cushionData.startingPosition : cushionData.raisedPosition);
        cameraController.focusOnCollectable(cameraFocus);
    }

    private void moveTo(Vector3 target)
    {
        moveTween?.Kill();

        moveTween = transform
            .DOMove(target, speed)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .SetLink(gameObject)
            .OnComplete(() => moveTween = null);
    }
}