namespace States
{
    public class StateGamePaused : GameState
    {
        public StateGamePaused(GameController manager) : base(manager) {}

        public override void OnMyStateEntered()
        {
            GameManager.ui.settingsButton();
        }

        public override void OnMyStateExit()
        {
            
        }
    }
}
