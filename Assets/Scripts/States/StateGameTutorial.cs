namespace States
{
    public class StateGameTutorial : GameState
    {
        public StateGameTutorial(GameController manager) : base(manager) {}

        public override void OnMyStateEntered()
        {
            GameManager.ui.tutorialUI();
        }

        public override void OnMyStateExit()
        {
            GameManager.ui.caseFileButton();
        }
        
    }
}
