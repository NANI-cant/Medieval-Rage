using System.Collections.Generic;
using Architecture.Services.General;
using Photon.Realtime;

namespace Architecture.Services.Network.Impl {
    public class MatchmakingService : IMatchmakingCallbacks {
        private readonly INetworkService _networkService;
        private readonly ISceneLoadService _sceneLoadService;

        public MatchmakingService(INetworkService networkService, ISceneLoadService sceneLoadService) {
            _networkService = networkService;
            _sceneLoadService = sceneLoadService;
            _networkService.AddCallbackTarget(this);
        }
        
        public void OnJoinRandomFailed(short returnCode, string message) {
            _networkService.CreateRoom();
        }

        public void OnLeftRoom() {
            _sceneLoadService.LoadLobby();
        }
        
        public void OnFriendListUpdate(List<FriendInfo> friendList) { }
        public void OnCreatedRoom() { }
        public void OnCreateRoomFailed(short returnCode, string message) { }
        public void OnJoinedRoom() { }
        public void OnJoinRoomFailed(short returnCode, string message) { }
    }
}