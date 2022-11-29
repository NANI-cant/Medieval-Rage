using UnityEngine.SceneManagement;

namespace Architecture.Services.Impl {
    public class UnitySceneLoadService: ISceneLoadService {
        private const string LobbyName = "Lobby";
        private const string LoadingScreenName = "LoadingScreen";
        private const string GameplayName = "Gameplay";

        public void LoadLobby() => SceneManager.LoadScene(LobbyName);
        public void LoadLoadingScreen() => SceneManager.LoadScene(LoadingScreenName);
        public void LoadGameplay() => SceneManager.LoadScene(GameplayName);
    }
}