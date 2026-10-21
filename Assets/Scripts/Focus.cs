using UnityEngine;

public class Focus : MonoBehaviour, IClickable
{
    [SerializeField] private CameraFocus cameraFocus;
    [SerializeField] private CameraController camera;


    public void OnClick()
    {
        camera.focusOnCollectable(cameraFocus);
    }
}
