using States;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Raycast controls;
    [SerializeField] public AudioManager audioManager;
    [SerializeField] public UI ui;
    
    // STATES
    private GameState currentState;
    public StateGameMainMenu stateGameMainMenu;
    public StateGameTutorial stateGameTutorial;
    public StateGamePlaying stateGamePlaying;
    public StateGamePaused stateGamePaused;

    private void Awake()
    {
        stateGameMainMenu = new StateGameMainMenu(this);
        stateGameTutorial = new StateGameTutorial(this);
        stateGamePlaying = new StateGamePlaying(this);
        stateGamePaused = new StateGamePaused(this);
    }
    private void Start()
    {
        NewGameState(stateGameTutorial);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.StateUpdate();
        }
    }

    public void NewGameState(GameState newState)
    {
        if (currentState != null)
        {
            currentState.OnMyStateExit();
        }
        currentState = newState;
        currentState.OnMyStateEntered();
    }
    
    public GameState GetCurrentState()
    {
        return currentState;
    }
    
    
}
