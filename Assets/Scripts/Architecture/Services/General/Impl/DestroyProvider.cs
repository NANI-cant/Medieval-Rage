using UnityEngine;

namespace Architecture.Services.General.Impl {
    public class DestroyProvider : IDestroyProvider {
        public void Destroy(GameObject gameObject) => Object.Destroy(gameObject);
        public void Destroy(Component component) => Object.Destroy(component);
    }
}