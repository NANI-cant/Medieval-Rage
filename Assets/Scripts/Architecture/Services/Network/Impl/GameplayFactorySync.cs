using Architecture.Services.Factories;
using Architecture.Services.General;
using ExitGames.Client.Photon;
using Gameplay.Setup;
using Network.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public class GameplayFactorySync {
        private readonly INetworkService _networkService;
        private readonly IDestroyProvider _destroyProvider;

        public GameplayFactorySync(
            INetworkService networkService,
            IGameplayFactory gameplayFactory,
            IDestroyProvider destroyProvider
        ) {
            _networkService = networkService;
            _destroyProvider = destroyProvider;

            gameplayFactory.PlayerCreated += SendPlayerOverNetwork;
        }

        private void SendPlayerOverNetwork(GameObject player) {
            var photonView = player.GetComponent<PhotonView>();
            if (_networkService.AllocateViewID(photonView)) {
                object[] data = {
                    player.transform.position,
                    player.transform.rotation,
                    photonView.ViewID
                };

                RaiseEventOptions raiseEventOptions = new RaiseEventOptions() {
                    Receivers = ReceiverGroup.Others,
                    CachingOption = EventCaching.AddToRoomCache
                };

                SendOptions sendOptions = new SendOptions() {
                    Reliability = true
                };

                _networkService.RaiseEvent(NetworkCode.InstantiatePlayer, data, raiseEventOptions, sendOptions);
            }
            else {
                Debug.LogError("Failed to allocate a ViewId.");
                _destroyProvider.Destroy(player);
            }
        }
    }
}