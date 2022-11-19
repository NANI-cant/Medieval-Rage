using UnityEngine;

namespace Architecture.Services.Impl {
    public class ResourcesPrefabProvider : IPrefabProvider {
        private const string PlayerPath = "Prefabs/Gameplay/Player";

        public GameObject PlayerCharacter => Resources.Load<GameObject>(PlayerPath);
    }
}
