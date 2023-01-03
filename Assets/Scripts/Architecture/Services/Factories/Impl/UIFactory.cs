using Architecture.Services.AssetProviding;
using Architecture.Services.Gameplay;
using Architecture.Services.General;
using Architecture.Services.Network;
using UI.EndGamePanel;
using UI.HUD;
using UnityEngine;

namespace Architecture.Services.Factories.Impl {
    public class UIFactory : IUIFactory {
        private readonly IUIProvider _uiProvider;
        private readonly IInstantiateProvider _instantiateProvider;
        private readonly IGameClock _gameClock;
        private readonly INetworkService _networkService;

        public UIFactory(
            IUIProvider uiProvider,
            IInstantiateProvider instantiateProvider,
            IGameClock gameClock,
            INetworkService networkService
        ) {
            _uiProvider = uiProvider;
            _instantiateProvider = instantiateProvider;
            _gameClock = gameClock;
            _networkService = networkService;
        }


        public GameObject CreateHUD() {
            var hud = _instantiateProvider.Instantiate(_uiProvider.HUD, Vector3.zero, Quaternion.identity);
            hud.GetComponent<HUD>().Construct(_gameClock);
            return hud;
        }

        public GameObject CreateEndGamePanel() {
            var endGamePanel = _instantiateProvider.Instantiate(_uiProvider.EndGamePanel, Vector3.zero, Quaternion.identity);
            endGamePanel.GetComponent<EndGamePanel>().Construct(_networkService);
            return endGamePanel;
        }
    }
}