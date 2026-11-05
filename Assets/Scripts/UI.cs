using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup ChangeViewButtons;
    public CanvasGroup ZoomViewButton;
    public CanvasGroup CaseFileButton;
    public CanvasGroup PauseScreen;
    
    [SerializeField] private GameController gameController;
    
    /*void Start()
    {
        CanvasGroupDisplayer.Show(ChangeViewButtons);
        CanvasGroupDisplayer.Hide(ZoomViewButton);
        CanvasGroupDisplayer.Hide(CaseFileButton);  
        CanvasGroupDisplayer.Hide(PauseScreen);
    }*/

    public void zoomButton()
    {
        CanvasGroupDisplayer.Hide(ChangeViewButtons);
        CanvasGroupDisplayer.Show(ZoomViewButton);
    }

    public void rotateButtons()
    {
        if (gameController.GetCurrentState() == gameController.stateGamePlaying)
        {
            CanvasGroupDisplayer.Show(ChangeViewButtons);
        }
        CanvasGroupDisplayer.Hide(ZoomViewButton);
    }

    public void caseFileButton()
    {
        CanvasGroupDisplayer.Show(CaseFileButton);
    }

    public void settingsButton()
    {
        gameController.NewGameState(gameController.stateGamePaused);
        CanvasGroupDisplayer.Show(PauseScreen);
    }

    public void resumeButton()
    {
        gameController.NewGameState(gameController.stateGamePlaying);
        CanvasGroupDisplayer.Hide(PauseScreen);
    }

    public void tutorialUI()
    {
        CanvasGroupDisplayer.Hide(ChangeViewButtons);
        CanvasGroupDisplayer.Hide(ZoomViewButton);
        CanvasGroupDisplayer.Hide(CaseFileButton);
        CanvasGroupDisplayer.Hide(PauseScreen);
    }
}
