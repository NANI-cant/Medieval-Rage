using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesUIProvider : IUIProvider {
        private const string HUDPath = "UI/HUD";

        public GameObject HUD => Resources.Load<GameObject>(HUDPath);
    }
}
