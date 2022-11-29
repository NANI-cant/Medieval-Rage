using UnityEngine;

namespace Gameplay.Fighting {
    public readonly struct TakeHitResult {
        public float MaxHealth { get; }
        public float CurrentHealth { get; }
        public float Damage { get; }
        public MonoBehaviour DamageDealer { get; }

        public TakeHitResult(float maxHealth, float currentHealth, float damage, MonoBehaviour damageDealer) {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            Damage = damage;
            DamageDealer = damageDealer;
        }
    }
}