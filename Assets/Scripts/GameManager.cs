using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] public BoardManager BoardManager { get; private set; }
    [field: SerializeField] public DiceManager DiceManager { get; private set; }

    [SerializeField] List<Player> _players;
    private int _currentPlayerIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void TakeStep()
    {
        int dice1 = 0;
        int dice2 = 0;

        int total = DiceManager.RollDice(out dice1, out dice2);

        _players[_currentPlayerIndex].Move(total);

        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }
}
