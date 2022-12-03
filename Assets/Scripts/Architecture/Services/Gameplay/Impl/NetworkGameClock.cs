using System;
using Architecture.Services.Network;
using ExitGames.Client.Photon;
using Network.Utils;
using Photon.Realtime;

namespace Architecture.Services.Gameplay.Impl {
    public class NetworkGameClock : IGameClock, IOnEventCallback {
        private readonly INetworkService _networkService;

        public event Action EnemiesShouldSpawn;
        public event Action Ticked;

        public float Time { get; private set; }

        public NetworkGameClock(INetworkService networkService) {
            _networkService = networkService;
        }
        
        public void Start() {
            _networkService.AddCallbackTarget(this);        
        }

        public void Stop() {
            _networkService.RemoveCallbackTarget(this);
        }

        public void OnEvent(EventData photonEvent) {
            if (photonEvent.Code != NetworkCode.GameClockTime) return;
            
            object[] data = (object[]) photonEvent.CustomData;
            Time = (float) data[0];
            Ticked?.Invoke();
        }
    }
}