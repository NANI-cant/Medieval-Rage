namespace Gameplay.Setup {
    public interface IEnemySpawnPoint: ISpawnPoint {
        EnemyPack[] Packs { get; }
    }
}