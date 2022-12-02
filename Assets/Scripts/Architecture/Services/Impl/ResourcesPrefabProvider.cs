using Gameplay.Setup;
using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesPrefabProvider : IPrefabProvider {
        private const string RootPath = "Gameplay/";
        private const string EnemiesFolder = "Enemies/";
        private const string PlayerCharacterPath = "Player";

        private string PlayerPath => RootPath + PlayerCharacterPath;
        public GameObject Player => Resources.Load<GameObject>(PlayerPath);

        private string EnemyPath(EnemyId enemyId) => RootPath + EnemiesFolder + enemyId;
        public GameObject Enemy(EnemyId enemyId) => Resources.Load<GameObject>(EnemyPath(enemyId));
    }
}
