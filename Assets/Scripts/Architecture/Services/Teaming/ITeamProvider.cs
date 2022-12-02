namespace Architecture.Services.Teaming {
    public interface ITeamProvider {
        int EnemyTeamId { get; }
        int NextPlayerTeamId { get; }
    }
}