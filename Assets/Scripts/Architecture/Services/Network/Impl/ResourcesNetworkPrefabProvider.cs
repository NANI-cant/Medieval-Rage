using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Network.Impl {
    public class ResourcesNetworkPrefabProvider : INetworkPrefabProvider {
        private const string PlayerPath = "Gameplay/Network/PlayerAvatar";
        private const string EnemiesFolder = "Gameplay/Enemies/Network/";
        
        public GameObject Player => Resources.Load<GameObject>(PlayerPath);

        public GameObject Enemy(EnemyId enemyId) => Resources.Load<GameObject>(EnemiesFolder + enemyId.ToString() + "Avatar");
    }
}