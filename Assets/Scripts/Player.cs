using UnityEngine;

public class Player : MonoBehaviour
{
    private int _currentTileIndex = 0;
    private Transform _playerTransorm;

    private void Awake()
    {
        _playerTransorm = GetComponentInChildren<Transform>();
    }

    public void Move(int countSteps)
    {
        _currentTileIndex = (_currentTileIndex + countSteps) % BoardManager.Instance.CountTiles;

        var tileTransorm = BoardManager.Instance.GetTile(_currentTileIndex);

        _playerTransorm.position = new Vector3(tileTransorm.position.x, tileTransorm.position.y);
    }
}
