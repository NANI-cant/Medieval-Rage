namespace Architecture.Services.Network {
    public interface INetworkService {
        int PlayersCount{ get; }
        bool IsMaster { get; }
        bool AutomaticallySyncScene { get; set; }
        
        bool ConnectToServer();
        bool JoinLobby();
        void AddCallbackTarget(object target);
        void LoadGameplay();
        bool JoinRandom();
        bool CreateRoom();
    }
}