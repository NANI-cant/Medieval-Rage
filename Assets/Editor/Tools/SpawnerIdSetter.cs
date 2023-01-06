using Gameplay.Setup.Impl;
using UnityEditor;
using UnityEngine;

namespace Tools {
    public class SpawnerIdSetter {
        [MenuItem("Tools/Spawner Id Setter/Set")]
        public static void LoadingScreen() {
            int id = 1;
            foreach (var spawner in GameObject.FindObjectsOfType<EnemySpawner>()) {
                
            }
        }
    }
}