namespace Gameplay.Fighting {
    public interface IDamageable{
        void TakeHit(IReadOnlyAttackData attackData);
    }
}