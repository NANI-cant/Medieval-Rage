using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesUIProvider : IUIProvider {
        private const string JoystickPath = "UI/Joystick";

        public GameObject Joystick => Resources.Load<GameObject>(JoystickPath);
    }
}
