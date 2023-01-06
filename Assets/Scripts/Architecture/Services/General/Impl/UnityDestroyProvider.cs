using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Architecture.Services.General.Impl {
    public class UnityDestroyProvider : IDestroyProvider {
        public event Action<GameObject> Destroyed;

        public void Destroy(GameObject gameObject) {
            Destroyed?.Invoke(gameObject);
            Object.Destroy(gameObject);
        }   
        public void Destroy(Component component) => Object.Destroy(component);
    }
}