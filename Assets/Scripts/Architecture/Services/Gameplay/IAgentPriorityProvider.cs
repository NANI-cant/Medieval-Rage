namespace Architecture.Services.Gameplay {
    public interface IAgentPriorityProvider {
        int NextPriority { get; }
    }
}