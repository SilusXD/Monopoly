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
        _currentTileIndex = (_currentTileIndex + countSteps) % GameManager.Instance.BoardManager.CountTiles;

        var tile = GameManager.Instance.BoardManager.GetTile(_currentTileIndex);

        var a = tile.transform.position.x;
        var b = tile.transform.position.y;

        _playerTransorm.position = new Vector3(a, b);
    }
}
