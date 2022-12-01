using UnityEngine;

namespace Architecture.Services {
    public interface INetworkInstantiateProvider {
        GameObject Instantiate(string path, Vector3 position, Quaternion rotation);
        GameObject Instantiate(string path, Vector3 position, Quaternion rotation, Transform parent);
    }
}