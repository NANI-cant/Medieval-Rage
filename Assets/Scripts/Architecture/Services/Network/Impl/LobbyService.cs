using System.Collections.Generic;
using Architecture.Services.General;
using Photon.Realtime;

namespace Architecture.Services.Network.Impl {
    public class LobbyService : ILobbyCallbacks {
        private readonly ISceneLoadService _sceneLoadService;

        public LobbyService(ISceneLoadService sceneLoadService) {
            _sceneLoadService = sceneLoadService;
        }
        
        public void OnJoinedLobby() => _sceneLoadService.LoadLobby();
        
        public void OnLeftLobby() { }
        public void OnRoomListUpdate(List<RoomInfo> roomList) { }
        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics) { }
    }
}