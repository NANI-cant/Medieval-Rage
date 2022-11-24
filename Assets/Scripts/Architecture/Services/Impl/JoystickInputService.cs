using UnityEngine;
using Extensions;
using Zenject;

namespace Architecture.Services.Impl {
    public class JoystickInputService : IInputService, ITickable {
        private const float Smoothness = 0.1f;
        
        private readonly Joystick _joystick;
        private bool _enabled = true;
        private Vector2 _lastJoystickValue = Vector2.zero;
        private Vector3 _direction;
        
        public Vector3 Direction => _direction;

        private Vector2 JoystickValue => _joystick.Direction;

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

        public void Tick() {
            if (_enabled == false) {
                _direction = Vector3.zero;
                return;
            }
            
            EnsureSmoothness();
        }

        private void EnsureSmoothness() {
            Vector2 validJoystickValue = JoystickValue;

            if (Vector2.Distance(_lastJoystickValue, JoystickValue) >= Smoothness) {
                Vector2 direction = JoystickValue - _lastJoystickValue;
                Vector2 smoothValue = _lastJoystickValue + direction * Smoothness;
                validJoystickValue = smoothValue;
            }

            _direction = validJoystickValue.ToXZ();
            _lastJoystickValue = validJoystickValue;
        }
    }
}
