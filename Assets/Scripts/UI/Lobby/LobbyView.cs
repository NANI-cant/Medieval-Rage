using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Lobby;

namespace UI.Lobby {
    public class LobbyView : MonoBehaviour {
        [Header("Quick game")] 
        [SerializeField] private Button _quickGameButton;
        
        private LobbyModel _lobbyModel;

        [Inject]
        public void Construct(LobbyModel lobbyModel) {
            _lobbyModel = lobbyModel;
        }

        private void OnEnable() => _quickGameButton.onClick.AddListener(FindQuickGame);
        private void OnDisable() => _quickGameButton.onClick.RemoveListener(FindQuickGame);

        private void FindQuickGame() => _lobbyModel.FindQuickGame();
    }
}