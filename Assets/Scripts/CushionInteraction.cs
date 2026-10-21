using UnityEngine;
using DG.Tweening;

public class CushionInteraction : MonoBehaviour, IClickable
{
    public CameraController cameraController;
    
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
            cameraController.getCurrentPosition() != cushionData.cameraViewPosition)
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
        Vector3 camPos = cameraController.getCurrentPosition();
        if (camPos != cushionData.cameraRoomZoom &&
            camPos != cushionData.cameraViewPosition)
        {
            Debug.Log("cannot move cushion");
            return;
        }
        moveTo(transform.position != cushionData.startingPosition ? cushionData.startingPosition : cushionData.raisedPosition);
        cameraController.checkUnderCushion(cushionData);
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