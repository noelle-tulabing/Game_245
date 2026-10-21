using UnityEngine;

[CreateAssetMenu(fileName = "NewCushion", menuName = "Cushion/Cushion")] 
public class Cushion : ScriptableObject
{
    // cushion positions
    public Vector3 startingPosition;
    public Vector3 raisedPosition;
    
    // camera positions
    public Vector3 cameraRoomZoom;
    public Vector3 cameraViewPosition;
    public Quaternion cameraViewRotation;
}
