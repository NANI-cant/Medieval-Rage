namespace Gameplay.Fighting {
    public readonly struct TakeHitResult {
        public float MaxHealth { get; }
        public float CurrentHealth { get; }
        public float Damage { get; }

        public TakeHitResult(float maxHealth, float currentHealth, float damage) {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            Damage = damage;
        }
    }
}