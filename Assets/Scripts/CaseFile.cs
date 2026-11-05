using UnityEngine;

public class CaseFile : MonoBehaviour, IClickable
{
    [SerializeField] private int fileNumber;
    public void OnClick()
    {
        // add selected file to game ui / progress checker (game controller)
    }
}
