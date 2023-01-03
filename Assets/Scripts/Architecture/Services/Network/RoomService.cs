using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Architecture.Services.Network {
    public class RoomService: IInRoomCallbacks, IOnEventCallback {
        private readonly INetworkService _networkService;

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
                
            }
        }

        public void OnEvent(EventData photonEvent) {
            
        }

        public void OnPlayerLeftRoom(Player otherPlayer) { }
        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) { }
        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps) { }
    }
}