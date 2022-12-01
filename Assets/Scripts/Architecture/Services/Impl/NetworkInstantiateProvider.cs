using Photon.Pun;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class NetworkInstantiateProvider : INetworkInstantiateProvider {
        public GameObject Instantiate(string path, Vector3 position, Quaternion rotation) {
            return PhotonNetwork.Instantiate(path, position, rotation);
        }

        public GameObject Instantiate(string path, Vector3 position, Quaternion rotation, Transform parent) {
            var gameObject = PhotonNetwork.Instantiate(path, position, rotation);
            gameObject.transform.parent = parent;
            return gameObject;
        }
    }
}