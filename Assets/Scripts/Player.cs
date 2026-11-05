using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public GameController manager;
    [SerializeField] private Inventory _inventory;
    [SerializeField] protected int _filesFound;

    void Start()
    {
        _filesFound = 0;
    }

    public int GetFilesFound()
    {
        return _filesFound;
    }

    protected void newFileFound()
    {
        _filesFound++;
    }
}
