using UnityEngine;

public class GameState
{
   public enum GameStateType
   {
      MainMenu,
      Tutorial, // 
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
