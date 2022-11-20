﻿using UnityEngine;

namespace Gameplay.Setup.Impl {
    public class EnemySpawnPoint: MonoBehaviour, IEnemySpawnPoint {
        [SerializeField] private EnemyPack[] _packs;
        
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
        public EnemyPack[] Packs => _packs;
    }
}

