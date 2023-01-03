using Gameplay.Enemy;
using Gameplay.Enemy.StateMachine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Network.Gameplay{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(PhotonView))]
    public class EnemyOwnership : MonoBehaviour, IOnPhotonViewControllerChange{
        private Enemy _enemy;
        private PhotonView _view;

        private void Awake() {
            _enemy = GetComponent<Enemy>();
            _view = GetComponent<PhotonView>();
            
            _view.AddCallbackTarget(this);
        }

        public void OnControllerChange(Player newController, Player previousController) {
            if (!_view.IsMine) return;
            
            _enemy.StateMachine.TranslateTo<CalmState>();
        }
    }
}
