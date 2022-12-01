using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesPrefabProvider : IPrefabProvider {
        private const string RootPath = "Prefabs/Gameplay/";
        private const string EnemiesFolder = "Enemies/";
        private const string PlayerCharacterPath = "Player";

        public string PlayerPath => RootPath + PlayerCharacterPath;
        public GameObject PlayerCharacter => Resources.Load<GameObject>(PlayerPath);

        public string EnemyPath(EnemyId enemyId) => RootPath + EnemiesFolder + enemyId;
        public GameObject Enemy(EnemyId enemyId) => Resources.Load<GameObject>(EnemyPath(enemyId));
    }
}
