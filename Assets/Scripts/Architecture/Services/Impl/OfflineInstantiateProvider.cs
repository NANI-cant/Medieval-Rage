using UnityEngine;

namespace Architecture.Services.Impl {
    public class OfflineInstantiateProvider : INetworkInstantiateProvider {
        private readonly IInstantiateProvider _instantiateProvider;

        public OfflineInstantiateProvider(IInstantiateProvider instantiateProvider) {
            _instantiateProvider = instantiateProvider;
        }

        public GameObject Instantiate(string path, Vector3 position, Quaternion rotation) {
            var template = Resources.Load<GameObject>(path);
            return _instantiateProvider.Instantiate(template, position, rotation);
        }

        public GameObject Instantiate(string path, Vector3 position, Quaternion rotation, Transform parent) {
            var template = Resources.Load<GameObject>(path);
            return _instantiateProvider.Instantiate(template, position, rotation, parent);
        }
    }
}