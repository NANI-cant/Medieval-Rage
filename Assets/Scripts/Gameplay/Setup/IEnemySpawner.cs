namespace Gameplay.Setup {
    public interface IEnemySpawner: ISpawnPoint {
        EnemyPack[] Packs { get; }
    }
}