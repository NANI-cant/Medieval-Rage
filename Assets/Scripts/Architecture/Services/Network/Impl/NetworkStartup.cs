using Zenject;

namespace Architecture.Services.Network.Impl {
    public class NetworkStartup: IInitializable {
        private readonly INetworkService _networkService;

        public NetworkStartup(INetworkService networkService) {
            _networkService = networkService;
        }
        
        public void Initialize() {
            _networkService.ConnectToServer();
        }
    }
}