using UnityEngine;

public class GameState
{
   public enum GameStateType
   {
      MainMenu,
      Tutorial, // similar to game playing except locked in first room until first file folder found
      GamePlaying, // use files found as progress indicators 
      GamePaused, // esc key binding
      GameWon, // canvas screen
      GameLost // canvas screen
   }
   
   protected GameController GameManager;

   public GameState(GameController manager)
   {
      GameManager = manager;
   }
}
