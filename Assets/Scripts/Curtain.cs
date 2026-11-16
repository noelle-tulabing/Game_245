using System;
using UnityEngine;

public class Curtain : MonoBehaviour, IClickable
{
    public Mesh curtainOpen;
    public Mesh curtainClosed;
    [SerializeField] private MeshFilter curtainMeshFilter;
    [SerializeField] private GameObject windowIcons;
    void Start()
    {
        curtainMeshFilter = GetComponent<MeshFilter>();
        closeCurtain();
        windowIcons.SetActive(false);
    }

    public void OnEnable()
    {
        TvPuzzle.OnPuzzleSolved += showWindowIcons;
        TvPuzzle.OnPuzzleSolved += openCurtain;
    }

    public void OnDisable()
    {
        TvPuzzle.OnPuzzleSolved -= showWindowIcons;
        TvPuzzle.OnPuzzleSolved -= openCurtain;
    }

    public void OnClick()
    {
        if (CameraController.zoomedIn)
        {
            if (TvPuzzle.IsSolved())
            {
                // tv puzzle solved state? --> will have different interactions once puzzle solved
                // curtain will remain open w/ icons showing --> on click will now focus on window icons
            }
            if (curtainMeshFilter.sharedMesh == curtainClosed)
            {
                openCurtain();
            }
            else
            {
                closeCurtain();
            }
            
            
        }
    }

    private void openCurtain()
    {
        curtainMeshFilter.mesh = curtainOpen;
    }

    private void closeCurtain()
    {
        curtainMeshFilter.mesh = curtainClosed;
    }

    private void showWindowIcons()
    {
        windowIcons.SetActive(true);
    }
    
}
