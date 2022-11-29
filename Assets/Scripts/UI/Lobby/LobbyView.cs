using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Lobby {
    public class LobbyView : MonoBehaviour {
        [Header("Create")]
        [SerializeField] private Button _createButton;
        [SerializeField] private TMP_InputField _createInputField;
        
        [Header("Join")]
        [SerializeField] private Button _joinButton;
        [SerializeField] private TMP_InputField _joinInputField;

        public Button CreateButton => _createButton;
        public Button JoinButton => _joinButton;
        public TMP_InputField CreateInputField => _createInputField;
        public TMP_InputField JoinInputField => _joinInputField;
    }
}