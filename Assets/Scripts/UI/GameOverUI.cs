using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Displays the new score in the GameOverScene and also calculate top high scores.
 */
public class GameOverUI : MonoBehaviour
{
    private Score newScore;
    private int numHighScores = 5; // max total of 5 high scores
    private TextMeshProUGUI scoreText;
    private Score[] highscores;


    private void Awake()
    {
        highscores = new Score[numHighScores];
        for (int i = 0; i < numHighScores; i++)
        {
            highscores[i] = new Score("highscore" + (i + 1));
        }

        newScore = new Score("score");
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();

        CalculateNewHighScore(newScore.GetValue());

    }

    void Start()
    {
        scoreText.text = newScore.GetValue().ToString("000000");
    }

    /*
     *  Caclulate high score given the integer of newScore
     *  by placing all 5 high scores and newScore into an integer
     *  array, sorting them, and updating back the new values.
     */
    private void CalculateNewHighScore(int newScore)
    {
        int[] scores = new int[numHighScores + 1]; // +1 for our newScore

        for (int i = 0; i < numHighScores; i++)
        {
            scores[i] = highscores[i].GetValue();
        }

        // updated high scores are from index 0 to numHighScores-1
        scores[numHighScores] = newScore;
        Array.Sort(scores);

        // update high scores
        for (int i = 0; i < numHighScores; i++)
        {
            // numHighScores - 1: because scores are sorted in ascending order
            highscores[i].SetValue(scores[numHighScores - i]);
        }
    }
}
