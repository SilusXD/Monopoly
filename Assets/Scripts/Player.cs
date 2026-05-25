using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _currentTileIndex = 0;
    private Transform _playerTransorm;
    public event Action<Player> OnFinishedStep;

    private void Awake()
    {
        _playerTransorm = GetComponentInChildren<Transform>();
    }

    public IEnumerator Move(int countSteps)
    {
        for (int i = 0; i < countSteps; i++)
        {
            _currentTileIndex++;

            if (_currentTileIndex >= GameManager.Instance.BoardManager.CountTiles)
            {
                _currentTileIndex = 0;
            }

            var tile = GameManager.Instance.BoardManager.GetTile(_currentTileIndex);

            while (Vector3.Distance(transform.position, tile.transform.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, tile.transform.position, 3 * Time.deltaTime);

                yield return null;
            }

            transform.position = tile.transform.position;
            
        }

        OnFinishedStep?.Invoke(this);
    }
}
