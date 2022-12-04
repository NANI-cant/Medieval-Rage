namespace Architecture.Services.Gameplay.Impl {
    public class AgentPriorityProvider : IAgentPriorityProvider {
        private int _nextPriority = 1;
        
        public int NextPriority => _nextPriority++;
    }
}