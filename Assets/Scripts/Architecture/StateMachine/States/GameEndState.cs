using Architecture.Services.Factories;
using Architecture.Services.Gameplay;

namespace Architecture.StateMachine.States {
    public class GameEndState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameClock _gameClock;
        private readonly IUIFactory _uiFactory;
        private readonly IInputService _inputService;

        public GameEndState(
            GameStateMachine gameStateMachine,
            IGameClock _gameClock,
            IUIFactory uiFactory,
            IInputService inputService
            ) {
            _gameStateMachine = gameStateMachine;
            this._gameClock = _gameClock;
            _uiFactory = uiFactory;
            _inputService = inputService;
        }

        public override void Enter() {
            _gameClock.Stop();
            _inputService.Disable();
            _uiFactory.CreateEndGamePanel();
        }
    }
}