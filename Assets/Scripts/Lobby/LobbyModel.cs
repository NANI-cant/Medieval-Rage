using System.Collections.Generic;
using Architecture.Services;
using Photon.Realtime;

namespace Lobby {
    public class LobbyModel{
        private readonly INetworkService _networkService;
        private readonly ICoroutineRunner _coroutineRunner;
        private List<RoomInfo> _roomList = new ();

        public LobbyModel(INetworkService networkService, ICoroutineRunner coroutineRunner) {
            _networkService = networkService;
            _coroutineRunner = coroutineRunner;
        }

        public bool FindQuickGame() {
            return _networkService.JoinRandom();
        }
    }
}