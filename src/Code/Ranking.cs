using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have created this Ranking structure to hold the players name and score.
/// </summary>

public struct Ranking
{
    public string name;
    public int score;

    public Ranking(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
