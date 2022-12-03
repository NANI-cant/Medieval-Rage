using Photon.Pun;
using UnityEngine;

namespace Network.Gameplay {
    [RequireComponent(typeof(Animator))]
    public class AnimatorSync: MonoBehaviour, IPunObservable{
        private Animator _animator;

        private void Awake() {
            _animator = GetComponent<Animator>();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
            if (stream.IsWriting) {
                var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
                var nameHash = stateInfo.shortNameHash;
                stream.Serialize(ref nameHash);
            }
            else {
                int nameHash = 0;
                stream.Serialize(ref nameHash);
                _animator.Play(nameHash, 0);
            }
        }
    }
}