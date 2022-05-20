using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
    private int score1;
    private int score2;
    private int score3;
    private int score4;
    private int score5;

    private TextMeshProUGUI score1Text;
    private TextMeshProUGUI score2Text;
    private TextMeshProUGUI score3Text;
    private TextMeshProUGUI score4Text;
    private TextMeshProUGUI score5Text;


    private void Awake()
    {
        score1 = PlayerPrefs.GetInt("highScore1", 0);
        score2 = PlayerPrefs.GetInt("highScore2", 0);
        score3 = PlayerPrefs.GetInt("highScore3", 0);
        score4 = PlayerPrefs.GetInt("highScore4", 0);
        score5 = PlayerPrefs.GetInt("highScore5", 0);

        score1Text = GameObject.FindGameObjectWithTag("HighScore1").GetComponent<TextMeshProUGUI>();
        score2Text = GameObject.FindGameObjectWithTag("HighScore2").GetComponent<TextMeshProUGUI>();
        score3Text = GameObject.FindGameObjectWithTag("HighScore3").GetComponent<TextMeshProUGUI>();
        score4Text = GameObject.FindGameObjectWithTag("HighScore4").GetComponent<TextMeshProUGUI>();
        score5Text = GameObject.FindGameObjectWithTag("HighScore5").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        score1Text.text = score1.ToString("000000");
        score2Text.text = score2.ToString("000000");
        score3Text.text = score3.ToString("000000");
        score4Text.text = score4.ToString("000000");
        score5Text.text = score5.ToString("000000");
    }
}
