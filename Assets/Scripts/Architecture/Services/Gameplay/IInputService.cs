using UnityEngine;

namespace Architecture.Services.Gameplay {
    public interface IInputService {
        Vector3 Direction { get; }
        void Enable();
        void Disable();
    }
}