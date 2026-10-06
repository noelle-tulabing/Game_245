using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool gameOver = false;
    public GameObject ceiling;
    void Start()
    {
        ceiling.SetActive(true);
    }

    private void Update()
    {
        while (gameOver == false)
        {
            gameOver = true;
        }
        ceiling.SetActive(false);
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void endGame()
    {
        gameOver = true;
    }

}
