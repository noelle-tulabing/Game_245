using UnityEngine;

public class Vent : MonoBehaviour, IClickable
{
    public Focus VentFocus;

    public void OnClick()
    {
        VentFocus.OnClick();
    }
}
