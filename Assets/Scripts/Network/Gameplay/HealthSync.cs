using System;
using Gameplay.Fighting;
using Gameplay.Health;
using Photon.Pun;
using UnityEngine;

namespace Network.Gameplay {
    [RequireComponent(typeof(PhotonView))]
    [RequireComponent(typeof(IHealth))]
    public class HealthSync: MonoBehaviour{
        private IHealth _health;
        private PhotonView _view;

        private void Awake() {
            _health = GetComponent<Health>();
            _view = GetComponent<PhotonView>();
        }

        private void OnEnable() => _health.HitTaken += OnHitTaken;
        private void OnDisable() => _health.HitTaken -= OnHitTaken;

        private void OnHitTaken(TakeHitResult hitResult) {
            float damage = hitResult.Damage;
            int damageDealerId = hitResult.DamageDealer.GetComponent<PhotonView>().ViewID;
            _view.RPC(nameof(ProvideHitOverNetwork), RpcTarget.OthersBuffered, damage, damageDealerId);
        }

        [PunRPC]
        private void ProvideHitOverNetwork(float damage, int damageDealerId) {
            var attackData = new AttackData {Damage = damage};
            MonoBehaviour damageDealer = PhotonNetwork.GetPhotonView(damageDealerId).GetComponent<MonoBehaviour>();
            _health.HitTaken -= OnHitTaken;
            _health.TakeHit(attackData, damageDealer);
            _health.HitTaken += OnHitTaken;
        }
    }
}