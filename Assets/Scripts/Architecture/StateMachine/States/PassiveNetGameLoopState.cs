using Architecture.Services.Network;

namespace Architecture.StateMachine.States {
    public class PassiveNetGameLoopState : State {
        private readonly GameStateMachine _gameStateMachine;
        private readonly INetworkService _networkService;
        private readonly RoomService _roomService;

        public PassiveNetGameLoopState(
            GameStateMachine gameStateMachine, 
            INetworkService networkService, 
            RoomService roomService
        ) {
            _gameStateMachine = gameStateMachine;
            _networkService = networkService;
            _roomService = roomService;
        }

        public override void Enter() => _roomService.IAmMasterNow += TranslateToMasterGameLoop;
        public override void Exit() => _roomService.IAmMasterNow -= TranslateToMasterGameLoop;

        private void TranslateToMasterGameLoop() => _gameStateMachine.TranslateTo<GameLoopState>();
    }
}