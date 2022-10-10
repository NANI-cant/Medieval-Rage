using System;
using UnityEngine;

namespace Architecture.Services {
    public interface IInputService {
        event Action<Vector3> TapDetected;
        void Enable();
        void Disable();
    }
}