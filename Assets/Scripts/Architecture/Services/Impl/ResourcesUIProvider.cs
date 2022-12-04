using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesUIProvider : IUIProvider {
        private const string HUDPath = "UI/HUD";
        private const string EndGamePanelPath = "UI/EndGamePanel";

        public GameObject HUD => Resources.Load<GameObject>(HUDPath);
        public GameObject EndGamePanel => Resources.Load<GameObject>(EndGamePanelPath); 
    }
}
