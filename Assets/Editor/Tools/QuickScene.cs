using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tools {
    public static class QuickScene {
        private const string GameplayScenePath = "Assets/Scenes/Gameplay.unity";
        private const string LobbyScenePath = "Assets/Scenes/Lobby.unity"; 
        private const string LoadingScreenScenePath = "Assets/Scenes/LoadingScreen.unity"; 
        
        [MenuItem("Tools/QuickScene/Loading Screen")]
        public static void LoadingScreen() => QuickOpen(LoadingScreenScenePath);

        [MenuItem("Tools/QuickScene/Lobby")]
        public static void Lobby() => QuickOpen(LobbyScenePath);

        [MenuItem("Tools/QuickScene/Gameplay")]
        public static void Gameplay() => QuickOpen(GameplayScenePath);

        private static void QuickOpen(string scenePath) {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
            
            EditorSceneManager.OpenScene(scenePath);
        }
    }
}