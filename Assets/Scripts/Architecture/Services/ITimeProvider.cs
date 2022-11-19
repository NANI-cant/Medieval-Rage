namespace Architecture.Services {
    public interface ITimeProvider {
        float DeltaTime { get; }
        float Time { get; }
        float UnscaledDeltaTime { get; }
        float UnscaledTime { get; }
    }
}
