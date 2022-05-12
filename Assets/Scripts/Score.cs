using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int baseScoreIncrease = 10;
    public int baseScoreDecrease = 10;

    private int score;

    private TextMeshProUGUI scoreText;

    public void Awake()
    {
        PlayerPrefs.SetInt("score", 0);
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void increaseScore()
    {
        score += baseScoreIncrease;
        saveScore();
        updateScoreText();
    }

    public void decreaseScore()
    {
        score -= baseScoreDecrease;
        saveScore();
        updateScoreText();
    }

    public int getScore()
    {
        return score;
    }

    private void updateScoreText()
    {
        scoreText.text = PlayerPrefs.GetInt("score", 0).ToString("000000");
    }

    private void saveScore()
    {
        PlayerPrefs.SetInt("score", score);
    }
}
