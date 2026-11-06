namespace States
{
    public class StateGamePlaying : GameState
    {
        public StateGamePlaying(GameController manager) : base(manager) {}

        public override void OnMyStateEntered()
        {
            GameManager.ui.playingStateUI();
        }

        public override void OnMyStateExit()
        {
            
        }

        public override void StateUpdate()
        {
            
        }

        public override void OnEventRecieved(GameStateType stateType)
        {
            base.OnEventRecieved(stateType);
        }
    }
}
