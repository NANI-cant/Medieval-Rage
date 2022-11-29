using System;
using Architecture.Services;
using UI.Lobby;

namespace Lobby {
    public class Lobby: IDisposable {
        private readonly LobbyView _lobbyView;
        private readonly INetworkService _networkService;

        public Lobby(LobbyView lobbyView, INetworkService networkService) {
            _lobbyView = lobbyView;
            _networkService = networkService;
            
            _lobbyView.CreateButton.onClick.AddListener(TryCreateRoom);
            _lobbyView.JoinButton.onClick.AddListener(TryJoinRoom);
        }

        public void Dispose() {
            _lobbyView.CreateButton.onClick.RemoveListener(TryCreateRoom);
            _lobbyView.JoinButton.onClick.RemoveListener(TryJoinRoom);
        }

        private void TryCreateRoom() => _networkService.CreateRoom(_lobbyView.CreateInputField.text);
        private void TryJoinRoom() => _networkService.JoinRoom(_lobbyView.JoinInputField.text);
    }
}