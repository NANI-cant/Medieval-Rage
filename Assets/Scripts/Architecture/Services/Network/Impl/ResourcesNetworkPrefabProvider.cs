using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public class ResourcesNetworkPrefabProvider : INetworkPrefabProvider {
        private const string PlayerPath = "Gameplay/Network/PlayerAvatar";

        public GameObject Player => Resources.Load<GameObject>(PlayerPath);
    }
}