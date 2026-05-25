using System.Collections.Generic;
using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] public BoardManager BoardManager { get; private set; }
    [field: SerializeField] public DiceManager DiceManager { get; private set; }

    [SerializeField] List<Player> _players;
    private int _currentPlayerIndex = 0;
    private bool _canTakeStep = true;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        foreach (var player in _players)
        {
            player.OnFinishedStep += EndStep;
        }
    }

    private void OnDisable()
    {
        foreach (var player in _players)
        {
            player.OnFinishedStep -= EndStep;
        }
    }

    private void ChangeCanTakeStepState(bool state)
    {
        _canTakeStep = state;
    }

    private void EndStep(Player player)
    {
        ChangeCanTakeStepState(true);
    }


    public void TakeStep()
    {
        if (!_canTakeStep)
        {
            return;
        }

        ChangeCanTakeStepState(false);

        int dice1 = 0;
        int dice2 = 0;

        int total = DiceManager.RollDice(out dice1, out dice2);

        StartCoroutine(_players[_currentPlayerIndex].Move(total));
        
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }
}
