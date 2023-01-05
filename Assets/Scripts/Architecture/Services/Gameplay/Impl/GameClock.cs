using System;
using Architecture.Services.General;
using Architecture.Services.Network;
using ExitGames.Client.Photon;
using Network.Utils;
using Photon.Realtime;
using Zenject;

namespace Architecture.Services.Gameplay.Impl {
    public class GameClock: IGameClock, ITickable, IOnEventCallback {
        private readonly ITimeProvider _timeProvider;
        private readonly INetworkService _networkService;
        private bool _isStopped = true;

        public GameClock(ITimeProvider timeProvider, INetworkService networkService) {
            _timeProvider = timeProvider;
            _networkService = networkService;
        }
        
        public event Action BossShouldSpawn;
        public event Action EnemiesShouldSpawn;
        public event Action Ticked;

        public float Time { get; private set; } = 0;

        public void Start() {
            _networkService.AddCallbackTarget(this);
            _isStopped = false;   
        }

        public void Stop() {
            _networkService.RemoveCallbackTarget(this);
            _isStopped = true;    
        }
        

        public void Tick() {
            if(!_networkService.IsMaster) return;
            if(_isStopped) return;
            
            Time += _timeProvider.DeltaTime;
            SendTimeThroughNet();

            if (Time <= _timeProvider.DeltaTime) BossShouldSpawn?.Invoke();
            if (Time % 30 <= _timeProvider.DeltaTime) EnemiesShouldSpawn?.Invoke();
            
            Ticked?.Invoke();
        }

        public void OnEvent(EventData photonEvent) {
            if (photonEvent.Code != NetworkCode.GameClockTime) return;
            
            object[] data = (object[]) photonEvent.CustomData;
            Time = (float) data[0];
            Ticked?.Invoke();
        }
        
        private void SendTimeThroughNet() {
            object[] data = {
                Time
            };

            var raiseEventOptions = new RaiseEventOptions() {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.DoNotCache
            };

            var sendOptions = new SendOptions() {
                Reliability = true
            };

            _networkService.RaiseEvent(NetworkCode.GameClockTime, data, raiseEventOptions, sendOptions);
        }
    }
}