using System;
using ExitGames.Client.Photon;
using Gameplay.Setup;
using Network.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public partial class GameNetEventsService : IOnEventCallback {
        private readonly INetworkService _networkService;

        public event Action GameEnded;
        public event Action<EnemyNetSpawnData> EnemySpawned;

        public GameNetEventsService(INetworkService networkService) {
            _networkService = networkService;

            _networkService.AddCallbackTarget(this);
        }

        public void RaiseGameEnd() {
            object[] data = { };

            var raiseEventOptions = new RaiseEventOptions() {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            var sendOptions = new SendOptions() {
                Reliability = true
            };

            _networkService.RaiseEvent(NetworkCode.GameEnded, data, raiseEventOptions, sendOptions);
        }

        public void RaiseEnemySpawn(GameObject enemy, EnemyId enemyId, int spawnerId) {
            var photonView = enemy.GetComponent<PhotonView>();
            if (!_networkService.AllocateViewID(photonView)) {
                Debug.LogError($"Failed to allocate a ViewId of {enemy.name}");
                return;
            }

            object[] data = {
                photonView.ViewID,
                enemyId,
                enemy.transform.position,
                enemy.transform.rotation,
                spawnerId,
            };

            RaiseEventOptions raiseEventOptions = new RaiseEventOptions() {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            SendOptions sendOptions = new SendOptions() {
                Reliability = true
            };

            _networkService.RaiseEvent(NetworkCode.InstantiateEnemy, data, raiseEventOptions, sendOptions);
        }

        public void OnEvent(EventData photonEvent) {
            if (photonEvent.Code == NetworkCode.GameEnded) GameEnded?.Invoke();

            if (photonEvent.Code == NetworkCode.InstantiateEnemy) {
                object[] data = (object[]) photonEvent.CustomData;
                var enemyData = new EnemyNetSpawnData(
                    (int) data[0],
                    (EnemyId) data[1],
                    (Vector3) data[2],
                    (Quaternion) data[3],
                    (int) data[4]
                );
                EnemySpawned?.Invoke(enemyData);
            }
        }
    }
}