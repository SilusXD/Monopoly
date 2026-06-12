using UnityEngine;
using UnityEngine.UIElements;

public class LobbyInterfaceController : MonoBehaviour
{
    private VisualElement _ui;
    private Button _lobbyCodeCopyButton;
    private Label _lobbyCodeLabel;

    private void Awake()
    {
        _ui = GetComponent<UIDocument>().rootVisualElement;

        _lobbyCodeCopyButton = _ui.Q<Button>("lobby-code-button");
        _lobbyCodeLabel = _ui.Q<Label>("lobby-code-label");
    }

    private void OnEnable()
    {
        _lobbyCodeCopyButton.clicked += LobbyCodeCopyButtonClick;
    }

    private void OnDisable()
    {
        _lobbyCodeCopyButton.clicked -= LobbyCodeCopyButtonClick;
    }

    void LobbyCodeCopyButtonClick()
    {
        Debug.Log(_lobbyCodeLabel.text);
        GUIUtility.systemCopyBuffer = _lobbyCodeLabel.text;
    }
}
