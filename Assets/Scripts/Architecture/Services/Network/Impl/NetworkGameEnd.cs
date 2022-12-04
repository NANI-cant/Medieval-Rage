using Architecture.StateMachine;
using Architecture.StateMachine.States;
using ExitGames.Client.Photon;
using Network.Utils;
using Photon.Realtime;

namespace Architecture.Services.Network.Impl {
    public class NetworkGameEnd: IOnEventCallback {
        private readonly GameStateMachine _gameStateMachine;

        public NetworkGameEnd(
            INetworkService networkService,
            GameStateMachine gameStateMachine
        ) {
            _gameStateMachine = gameStateMachine;
            networkService.AddCallbackTarget(this);
        }
        
        public void OnEvent(EventData photonEvent) {
            if(photonEvent.Code != NetworkCode.GameEnded) return;
            
            _gameStateMachine.TranslateTo<GameEndState>();
        }
    }
}