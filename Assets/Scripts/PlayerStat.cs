using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int score;

    private void Start()
    {
        score = 0;
    }
    public static void AddScore(int amount)
    {
        score += amount;
    }
}
