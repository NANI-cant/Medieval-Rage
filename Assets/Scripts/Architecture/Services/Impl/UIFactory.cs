using UI.HUD;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class UIFactory : IUIFactory {
        private readonly IUIProvider _uiProvider;
        private readonly IInstantiateProvider _instantiateProvider;
        private readonly IGameClock _gameClock;

        public UIFactory(
            IUIProvider uiProvider,
            IInstantiateProvider instantiateProvider,
            IGameClock gameClock
        ) {
            _uiProvider = uiProvider;
            _instantiateProvider = instantiateProvider;
            _gameClock = gameClock;
        }


        public GameObject CreateHUD() {
            var hud =_instantiateProvider.Instantiate(_uiProvider.HUD, Vector3.zero, Quaternion.identity);
            hud.GetComponent<HUD>().Construct(_gameClock);
            return hud;
        }
    }
}