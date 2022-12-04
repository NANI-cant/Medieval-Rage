using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace Architecture.Services.Network {
    public interface INetworkService {
        int PlayersCount{ get; }
        bool IsMaster { get; }
        bool AutomaticallySyncScene { get; set; }

        bool ConnectToServer();
        bool JoinLobby();
        void AddCallbackTarget(object target);
        void RemoveCallbackTarget(object target);
        void LoadGameplay();
        bool JoinRandom();
        bool CreateRoom();
        bool RaiseEvent(byte code, object[] data, RaiseEventOptions raiseEventOptions, SendOptions sendOptions);
        bool AllocateViewID(PhotonView view);
        bool Leave();
    }
}