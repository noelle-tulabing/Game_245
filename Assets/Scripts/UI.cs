using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup ChangeViewButtons;
    public CanvasGroup ZoomViewButton;
    
    void Start()
    {
        CanvasGroupDisplayer.Show(ChangeViewButtons);
        CanvasGroupDisplayer.Hide(ZoomViewButton);
    }

    public void zoomButton()
    {
        CanvasGroupDisplayer.Hide(ChangeViewButtons);
        CanvasGroupDisplayer.Show(ZoomViewButton);
    }

    public void rotateButtons()
    {
        CanvasGroupDisplayer.Show(ChangeViewButtons);
        CanvasGroupDisplayer.Hide(ZoomViewButton);
    }
}
