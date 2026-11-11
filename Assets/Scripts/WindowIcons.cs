using UnityEngine;

public class WindowIcons : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        TvPuzzle.onPuzzleSolved += DisplayWindowIcons;
    }

    void OnDisable()
    {
        TvPuzzle.onPuzzleSolved -= DisplayWindowIcons;
    }

    private void DisplayWindowIcons()
    {
        gameObject.SetActive(true);
    }
}
