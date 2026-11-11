using States;
using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup ChangeViewButtons;
    public CanvasGroup ZoomViewButton;
    public CanvasGroup PlayingStateUI;
    public CanvasGroup PauseScreen;
    public CanvasGroup CaseFileMenu;
    
    [SerializeField] private GameController gameController;
    
    void Start()
    {
        CanvasGroupDisplayer.Hide(CaseFileMenu);
    }

    public void zoomButton()
    {
        CanvasGroupDisplayer.Hide(ChangeViewButtons);
        CanvasGroupDisplayer.Show(ZoomViewButton);
    }

    public void rotateButtons()
    {
        if (GameController.GetCurrentState() == gameController.stateGamePlaying)
        {
            CanvasGroupDisplayer.Show(ChangeViewButtons);
        }
        CanvasGroupDisplayer.Hide(ZoomViewButton);
    }

    public void playingStateUI()
    {
       CanvasGroupDisplayer.Hide(PauseScreen);
       CanvasGroupDisplayer.Show(PlayingStateUI);
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

    public void CaseFileUI()
    {
        if (CaseFileMenu.alpha == 1)
        {
            CanvasGroupDisplayer.Hide(CaseFileMenu);
        }
        else
        {
            CanvasGroupDisplayer.Show(CaseFileMenu);
        }
    }

    public void tutorialUI()
    {
        CanvasGroupDisplayer.Hide(ChangeViewButtons);
        CanvasGroupDisplayer.Hide(ZoomViewButton);
        CanvasGroupDisplayer.Hide(PlayingStateUI);
        CanvasGroupDisplayer.Hide(PauseScreen);
    }
}
