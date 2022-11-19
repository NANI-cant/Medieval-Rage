using System;
using UnityEngine;

namespace Architecture.Services {
    public interface IInputService {
        Vector3 Direction { get; }
        void Enable();
        void Disable();
    }
}