using UnityEngine;
using UnityEngine.UIElements;

public class GameInterfaceController : MonoBehaviour
{
    private VisualElement _ui;
    private Button _buttonRoll;

    private void Awake()
    {
        _ui = GetComponent<UIDocument>().rootVisualElement;

        _buttonRoll = _ui.Q<Button>("ButtonRoll");
    }

    private void OnEnable()
    {
        _buttonRoll.clicked += ButtonRollClick;
    }

    void ButtonRollClick()
    {
        GameManager.Instance.TakeStep();
    }
}
