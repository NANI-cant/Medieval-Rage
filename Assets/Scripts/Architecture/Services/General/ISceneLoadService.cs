namespace Architecture.Services.General {
    public interface ISceneLoadService {
        void LoadLobby();
        void LoadLoadingScreen();
        void LoadGameplay();
    }
}