using Photon.Pun;

namespace Architecture.Services.Impl {
    public class PhotonNetworkService : INetworkService {
        private const string GameplayName = "Gameplay";
        
        public bool ConnectToServer() => PhotonNetwork.ConnectUsingSettings();
        public bool JoinLobby() => PhotonNetwork.JoinLobby();
        public void AddCallbackTarget(object target) => PhotonNetwork.AddCallbackTarget(target);
        public void RemoveCallbackTarget(object target) => PhotonNetwork.RemoveCallbackTarget(target);
        public bool CreateRoom(string name) => PhotonNetwork.CreateRoom(name);
        public bool JoinRoom(string name) => PhotonNetwork.JoinRoom(name);
        public void LoadGameplay() => PhotonNetwork.LoadLevel(GameplayName);
    }
}