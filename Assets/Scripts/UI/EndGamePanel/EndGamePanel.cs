using Architecture.Services.Network;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EndGamePanel {
    public class EndGamePanel: MonoBehaviour {
        [SerializeField] private Button _leaveButton;
        private INetworkService _networkService;

        public void Construct(INetworkService networkService) {
            _networkService = networkService;
        }

        private void OnEnable() {
            _leaveButton.onClick.AddListener(Leave);
        }

        private void OnDisable() {
            _leaveButton.onClick.AddListener(Leave);
        }

        private void Leave() {
            _networkService.Leave();
        }
    }
}