using System;
using States;
using UnityEngine;

public class Raycast : MonoBehaviour
{
	public Camera mainCamera;
    public GameController gameController;
    public LayerMask clickable;
    
    [SerializeField] private PlayerInteraction player;
	void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameController.GetCurrentState() == gameController.stateGamePlaying || GameController.GetCurrentState() == gameController.stateGameTutorial)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, clickable))
                {
                    player.PlayerClicked(hit.transform.gameObject);
                }
            }
            else
            {
                return;
            }
            
        }
    }
}
