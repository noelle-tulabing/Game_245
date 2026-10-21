using UnityEngine;

[CreateAssetMenu(fileName = "NewCushion", menuName = "Cushion/Cushion")] 
public class Cushion : ScriptableObject
{
    // cushion positions
    public Vector3 startingPosition;
    public Vector3 raisedPosition;
}
