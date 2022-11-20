using System;
using UnityEngine;

namespace Gameplay.Setup {
    [Serializable]
    public struct EnemyPack {
        [SerializeField] private EnemyId[] _enemies;
        
        public EnemyId[] Enemies => _enemies;
    }
}