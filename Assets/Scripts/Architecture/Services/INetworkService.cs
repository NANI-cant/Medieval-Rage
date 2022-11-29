namespace Architecture.Services {
    public interface INetworkService {
        bool ConnectToServer();
        bool JoinLobby();
        void AddCallbackTarget(object target);
        bool CreateRoom(string name);
        bool JoinRoom(string name);
        void LoadGameplay();
    }
}