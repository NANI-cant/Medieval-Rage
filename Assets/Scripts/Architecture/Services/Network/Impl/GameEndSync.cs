using Architecture.StateMachine;
using ExitGames.Client.Photon;
using Gameplay.Setup;
using Network.Utils;
using Photon.Realtime;

namespace Architecture.Services.Network.Impl {
    public class GameEndSync {
        private readonly INetworkService _networkService;
        private readonly GameStateMachine _gameStateMachine;

        public GameEndSync(
            IBossSpawner bossSpawner,
            INetworkService networkService
        ) {
            _networkService = networkService;

            bossSpawner.Slayed += SendGameEndOverNetwork;
        }

        private void SendGameEndOverNetwork() {
            object[] data = { };

            var raiseEventOptions = new RaiseEventOptions() {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            var sendOptions = new SendOptions() {
                Reliability = true
            };

            _networkService.RaiseEvent(NetworkCode.GameEnded, data, raiseEventOptions, sendOptions);
        }
    }
}