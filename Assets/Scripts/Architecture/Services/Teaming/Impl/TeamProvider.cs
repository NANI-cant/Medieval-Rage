namespace Architecture.Services.Teaming.Impl {
    public class TeamProvider : ITeamProvider {
        private int lastPlayerTeamId = 1;
        
        public int EnemyTeamId => 0;
        public int NextPlayerTeamId => lastPlayerTeamId++;
    }
}