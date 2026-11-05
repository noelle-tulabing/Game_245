using UnityEngine;

namespace States
{
   public class GameState
   {
      public enum GameStateType
      {
         MainMenu,
         Tutorial, // similar to game playing except locked in first room until first file folder found
         GamePlaying, // use files found as progress indicators 
         GamePaused, // esc key binding
         GameWon, // canvas screen
      }
   
      public GameController GameManager;

      public GameState(GameController manager)
      {
         GameManager = manager;
      }

      public virtual void OnMyStateEntered() {}
      public virtual void OnMyStateExit() {}

      public virtual void StateUpdate() {}

      public virtual void OnEventRecieved(GameStateType stateType) {}
   }
}
