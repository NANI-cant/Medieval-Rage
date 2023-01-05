using System.Collections.Generic;
using Photon.Realtime;
using Zenject;

namespace Architecture.Services.Network.Impl {
    public class ConnectionService : IConnectionCallbacks, IInitializable {
        private readonly INetworkService _networkService;

        public ConnectionService(INetworkService networkService) {
            _networkService = networkService;
            _networkService.AddCallbackTarget(this);
        }
        
        public void Initialize() {
            _networkService.ConnectToServer();
        }

        public void OnConnectedToMaster() {
            _networkService.AutomaticallySyncScene = true;
            _networkService.JoinLobby();   
        }

        public void OnConnected() { }
        public void OnDisconnected(DisconnectCause cause) { }
        public void OnRegionListReceived(RegionHandler regionHandler) { }
        public void OnCustomAuthenticationResponse(Dictionary<string, object> data) { }
        public void OnCustomAuthenticationFailed(string debugMessage) { }
    }
}