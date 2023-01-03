using System.Collections.Generic;
using Architecture.Services.General;
using Photon.Realtime;

namespace Architecture.Services.Network.Impl {
    public class ConnectionCallbacks : IConnectionCallbacks, ILobbyCallbacks, IMatchmakingCallbacks {
        private readonly INetworkService _networkService;
        private readonly ISceneLoadService _sceneLoadService;

        public ConnectionCallbacks(INetworkService networkService, ISceneLoadService sceneLoadService) {
            _networkService = networkService;
            _sceneLoadService = sceneLoadService;
            _networkService.AddCallbackTarget(this);
        }
        
        public void OnJoinedLobby() => _sceneLoadService.LoadLobby();
        public void OnJoinRandomFailed(short returnCode, string message) => _networkService.CreateRoom();
        public void OnLeftRoom() => _sceneLoadService.LoadLobby();

        public void OnConnectedToMaster() {
            _networkService.AutomaticallySyncScene = true;
            _networkService.JoinLobby();   
        }

        public void OnJoinedRoom() { }
        public void OnConnected() { }
        public void OnDisconnected(DisconnectCause cause) { }
        public void OnRegionListReceived(RegionHandler regionHandler) { }
        public void OnCustomAuthenticationResponse(Dictionary<string, object> data) { }
        public void OnCustomAuthenticationFailed(string debugMessage) { }
        public void OnLeftLobby() { }
        public void OnRoomListUpdate(List<RoomInfo> roomList) { }
        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics) { }
        public void OnFriendListUpdate(List<FriendInfo> friendList) { }
        public void OnCreatedRoom() {}
        public void OnCreateRoomFailed(short returnCode, string message) { }
        public void OnJoinRoomFailed(short returnCode, string message) { }

    }
}