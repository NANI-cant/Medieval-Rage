namespace Architecture.StateMachine.States {
    public class GameLoopState : State {
        private readonly GameStateMachine _gameStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine) {
            _gameStateMachine = gameStateMachine;
        }
    }
}