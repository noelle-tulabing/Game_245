using UnityEngine;

public class Curtain : MonoBehaviour, IClickable
{
    public Mesh curtainOpen;
    public Mesh curtainClosed;
    [SerializeField] private MeshFilter curtainMeshFilter;
    void Start()
    {
        curtainMeshFilter = GetComponent<MeshFilter>();
    }

    public void OnClick()
    {
        /*if (TvPuzzle.IsSolved())
        {
            curtainMeshFilter.mesh = curtainOpen;
            return;
        }
        else*/ if (CameraController.zoomedIn)
        {
            if (curtainMeshFilter.sharedMesh == curtainClosed)
            {
                Debug.Log("curtain is closed");
                curtainMeshFilter.mesh = curtainOpen;
                Debug.Log("Curtain opened");
            }
            else
            {
                Debug.Log("curtain is open");
                curtainMeshFilter.mesh = curtainClosed;
                Debug.Log("Curtain closed");
            }
        }
    }
}
