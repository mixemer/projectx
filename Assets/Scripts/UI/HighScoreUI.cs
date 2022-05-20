using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
    private Score score1;
    private Score score2;
    private Score score3;
    private Score score4;
    private Score score5;

    private TextMeshProUGUI score1Text;
    private TextMeshProUGUI score2Text;
    private TextMeshProUGUI score3Text;
    private TextMeshProUGUI score4Text;
    private TextMeshProUGUI score5Text;


    private void Awake()
    {
        score1 = new Score("highscore1");
        score2 = new Score("highscore2");
        score3 = new Score("highscore3");
        score4 = new Score("highscore4");
        score5 = new Score("highscore5");

        score1Text = GameObject.FindGameObjectWithTag("HighScore1").GetComponent<TextMeshProUGUI>();
        score2Text = GameObject.FindGameObjectWithTag("HighScore2").GetComponent<TextMeshProUGUI>();
        score3Text = GameObject.FindGameObjectWithTag("HighScore3").GetComponent<TextMeshProUGUI>();
        score4Text = GameObject.FindGameObjectWithTag("HighScore4").GetComponent<TextMeshProUGUI>();
        score5Text = GameObject.FindGameObjectWithTag("HighScore5").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        score1Text.text = score1.GetValue().ToString("000000");
        score2Text.text = score2.GetValue().ToString("000000");
        score3Text.text = score3.GetValue().ToString("000000");
        score4Text.text = score4.GetValue().ToString("000000");
        score5Text.text = score5.GetValue().ToString("000000");
    }
}
