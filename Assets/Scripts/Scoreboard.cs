using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    int score;

    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }
}
