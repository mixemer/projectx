using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI scoreText;


    private void Awake()
    {
        score = PlayerPrefs.GetInt("score");
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        scoreText.text = score.ToString("000000");
    }
}
