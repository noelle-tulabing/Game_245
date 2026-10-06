using System;
using UnityEngine;

public class InteractionTest : MonoBehaviour, IClickable
{
    public PlayerInteraction player;

    public void OnClick()
    {
        print("door has been clicked");
        player.OnClick();
    }
}
