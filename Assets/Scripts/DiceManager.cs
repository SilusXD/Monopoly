using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public int RollDice(out int dice1, out int dice2)
    {
        dice1 = Random.Range(1, 7);
        dice2 = Random.Range(1, 7);

        return dice1 + dice2;
    }
}
