using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set; }

    [SerializeField] private List<Transform> tiles;
    public int CountTiles { get; private set; }

    private void Awake()
    {
        Instance = this;
        CountTiles = tiles.Count;
        /*for (int i = 0; i < tilesParent.transform.childCount; i++)
        {
            var child = tilesParent.transform.GetChild(i);
            tiles.Add(child);
        }*/
    }

    public Transform GetTile(int index)
    {
        return tiles[index].transform;
    }
}
