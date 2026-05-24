using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private List<Tile> tiles;
    [SerializeField] private GameObject tilesParent; 
    public int CountTiles { get; private set; }

    private void Awake()
    {
        tiles = tilesParent.GetComponentsInChildren<Tile>().ToList();
        CountTiles = tiles.Count;
    }

    public Tile GetTile(int index)
    {
        return tiles[index];
    }
}
