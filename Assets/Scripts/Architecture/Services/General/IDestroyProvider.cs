using System;
using UnityEngine;

namespace Architecture.Services.General {
    public interface IDestroyProvider {
        event Action<GameObject> Destroyed;
        
        void Destroy(GameObject gameObject);
        void Destroy(Component component);
    }
}