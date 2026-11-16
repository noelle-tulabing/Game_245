using UnityEngine;

public class WindowIcons : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        TvPuzzle.OnPuzzleSolved += DisplayWindowIcons;
    }

    void OnDisable()
    {
        TvPuzzle.OnPuzzleSolved -= DisplayWindowIcons;
    }

    private void DisplayWindowIcons()
    {
        gameObject.SetActive(true);
    }
}
