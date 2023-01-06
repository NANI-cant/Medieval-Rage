using System;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Architecture.Services.Network.Impl {
    public class RoomService: IInRoomCallbacks {
        private readonly INetworkService _networkService;

        public event Action IAmMasterNow;

        public RoomService(INetworkService networkService) {
            _networkService = networkService;
            
            _networkService.AddCallbackTarget(this);
        }

        public void OnPlayerEnteredRoom(Player newPlayer) {
            if (_networkService.PlayersCount == 2 && _networkService.IsMaster) {
                _networkService.LoadGameplay();
            }
        }

        public void OnMasterClientSwitched(Player newMasterClient) {
            if (_networkService.IsMaster) {
                IAmMasterNow?.Invoke();
            }
        }

        public void OnPlayerLeftRoom(Player otherPlayer) { }
        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) { }
        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps) { }
    }
}