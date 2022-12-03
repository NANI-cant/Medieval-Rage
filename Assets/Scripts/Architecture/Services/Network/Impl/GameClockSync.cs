using Architecture.Services.Gameplay;
using ExitGames.Client.Photon;
using Network.Utils;
using Photon.Realtime;

namespace Architecture.Services.Network.Impl {
    public class GameClockSync {
        private readonly IGameClock _gameClock;
        private readonly INetworkService _networkService;

        public GameClockSync(
            IGameClock gameClock,
            INetworkService networkService
        ) {
            _gameClock = gameClock;
            _networkService = networkService;

            _gameClock.Ticked += OnTicked;
        }

        private void OnTicked() {
            object[] data = {
                _gameClock.Time
            };

            var raiseEventOptions = new RaiseEventOptions() {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.DoNotCache
            };

            var sendOptions = new SendOptions() {
                Reliability = true
            };

            _networkService.RaiseEvent(NetworkCode.GameClockTime, data, raiseEventOptions, sendOptions);
        }
    }
}