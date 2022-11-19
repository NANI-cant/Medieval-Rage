using UnityEngine;
using Extensions;

namespace Architecture.Services.Impl {
    public class JoystickInputService : IInputService {
        private readonly Joystick _joystick;
        private bool _enabled = true;

        public Vector3 Direction => _enabled ? _joystick.Direction.ToXZ() : Vector3.zero;

        public JoystickInputService(Joystick joystick) {
            _joystick = joystick;
        }

        public void Enable() {
            _enabled = true;
            _joystick?.gameObject.SetActive(true);
        }
        public void Disable() {
            _enabled = false;
            _joystick?.gameObject.SetActive(false);
        }
    }
}
