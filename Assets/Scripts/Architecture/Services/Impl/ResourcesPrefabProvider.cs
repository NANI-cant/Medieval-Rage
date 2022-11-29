using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesPrefabProvider : IPrefabProvider {
        private const string RootPath = "Prefabs/Gameplay/";
        private const string EnemiesFolder = "Enemies/";
        private const string PlayerPath = "Player";

        public GameObject PlayerCharacter => Resources.Load<GameObject>(RootPath + PlayerPath);
        
        public GameObject Enemy(EnemyId enemyId) => Resources.Load<GameObject>(RootPath + EnemiesFolder + enemyId);
    }
}
