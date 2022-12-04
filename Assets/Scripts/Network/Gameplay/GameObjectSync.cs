using Photon.Pun;
using UnityEngine;

namespace Network.Gameplay {
    [RequireComponent(typeof(PhotonView))]
    public class GameObjectSync: MonoBehaviour, IPunObservable {
        private PhotonView _view;

        private void Awake() => _view = GetComponent<PhotonView>();

        private void OnDestroy() {
            if(!_view.IsMine) return;
            PhotonNetwork.Destroy(_view);   
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
            if (stream.IsWriting) {
                bool isActive = gameObject.activeInHierarchy;
                stream.Serialize(ref isActive);
            }
            else {
                bool isActive = false;
                stream.Serialize(ref isActive);
                gameObject.SetActive(isActive);
            }
        }
    }
}