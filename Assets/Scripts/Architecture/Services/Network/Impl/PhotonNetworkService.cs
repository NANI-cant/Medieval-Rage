using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace Architecture.Services.Network.Impl {
    public class PhotonNetworkService : INetworkService {
        private const string GameplayName = "Gameplay";

        public int PlayersCount => PhotonNetwork.PlayerList.Length;
        public bool IsMaster => PhotonNetwork.IsMasterClient;
        
        public bool AutomaticallySyncScene { 
            get => PhotonNetwork.AutomaticallySyncScene; 
            set => PhotonNetwork.AutomaticallySyncScene = value; 
        }

        public bool ConnectToServer() => PhotonNetwork.ConnectUsingSettings();
        public bool JoinLobby() => PhotonNetwork.JoinLobby();
        public void AddCallbackTarget(object target) => PhotonNetwork.AddCallbackTarget(target);
        public void RemoveCallbackTarget(object target) => PhotonNetwork.RemoveCallbackTarget(target);
        public bool JoinRoom(string name) => PhotonNetwork.JoinRoom(name);
        public void LoadGameplay() => PhotonNetwork.LoadLevel(GameplayName);
        public bool JoinRandom() => PhotonNetwork.JoinRandomRoom();
        public bool RaiseEvent(byte code, object[] data, RaiseEventOptions raiseEventOptions, SendOptions sendOptions) => PhotonNetwork.RaiseEvent(code, data, raiseEventOptions, sendOptions);
        public bool AllocateViewID(PhotonView view) => PhotonNetwork.AllocateViewID(view);
        public bool Leave() => PhotonNetwork.LeaveRoom();
        public int GetMyId() => PhotonNetwork.LocalPlayer.ActorNumber;

        public bool CreateRoom() {
            var options = new RoomOptions() {
                MaxPlayers = 4,
                CleanupCacheOnLeave = false,
                EmptyRoomTtl = 0,
            };
            return PhotonNetwork.CreateRoom(null, options);   
        }
    }
}