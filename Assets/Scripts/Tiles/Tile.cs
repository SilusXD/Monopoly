using UnityEngine;

public class Tile : MonoBehaviour
{
    public virtual void OnPlayerLanded(
        Player player)
    {
        Debug.Log(
            $"{player.name} landed on {name}");


    }
}
