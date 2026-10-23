using UnityEngine;

[CreateAssetMenu(fileName = "NewCameraView", menuName = "CameraView/CameraFocus")] 
public class CameraFocus : ScriptableObject
{
    // camera positions
    public Vector3 cameraViewPosition;
    public Quaternion cameraViewRotation;
}
