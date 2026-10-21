using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectable", menuName = "Collectable/CollectableData")] // do all collectables need a special camera view to pickup? 
public class CollectableData : ScriptableObject
{
    // camera positions
    public Vector3 cameraRoomZoom;
    public Vector3 cameraViewPosition;
    public Quaternion cameraViewRotation;
}
