using System;
using UnityEngine;

public class Curtain : MonoBehaviour, IClickable
{
    public Mesh curtainOpen;
    public Mesh curtainClosed;
    public MeshFilter curtainMeshFilter;
    public GameObject windowIcons;
    public Focus windowIconFocus;
    
    void Start()
    {
        curtainMeshFilter = GetComponent<MeshFilter>();
        closeCurtain();
        windowIcons.SetActive(false);
        windowIconFocus = windowIcons.GetComponent<Focus>();
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
                showWindowIcons();
                openCurtain();
                windowIconFocus.OnClick();
                return;
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
