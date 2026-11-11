using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public GameController manager;
    [SerializeField] private Inventory _inventory;
    private static int _filesFound;
    private static int _screwsUnscrewed;
    
    void Start()
    {
        _filesFound = 0;
        _screwsUnscrewed = 0;
    }

    private void OnEnable()
    {
        Collectable.OnUnscrewedScrew += ScrewUnscrewed;
    }

    private void OnDisable()
    {
        Collectable.OnUnscrewedScrew -= ScrewUnscrewed;
    }
    
    public static int GetFilesFound()
    {
        return _filesFound;
    }

    protected void NewFileFound()
    {
        _filesFound++;
    }

    public static int GetScrewsUnscrewed()
    {
        return _screwsUnscrewed;
    }
    
    private void ScrewUnscrewed()
    {
        _screwsUnscrewed++;
        
    }
}
