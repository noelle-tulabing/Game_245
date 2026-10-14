using UnityEngine;
using DG.Tweening;

public class CushionInteraction : MonoBehaviour, IClickable
{
    [SerializeField] private Cushion cushionData;
    public CameraController cameraController;
    private float speed = 5f;
    private Tween moveTween;
    private bool cushionUp;

    void Start()
    {
        transform.position = cushionData.startingPosition;
        cushionUp = false;
    }

    void Update() // still polling; see note below
    {
        if (cushionUp &&
            cameraController.getCurrentPosition() != cushionData.cameraViewPosition)
        {
            MoveTo(cushionData.startingPosition);
            cushionUp = false;
        }
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
        Debug.Log("moving cushion");
        MoveTo(cushionUp ? cushionData.startingPosition : cushionData.raisedPosition);
        cameraController.checkUnderCushion(cushionData);
        cushionUp = !cushionUp;
        Debug.Log("cushion done moving");
    }

    void MoveTo(Vector3 target)
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