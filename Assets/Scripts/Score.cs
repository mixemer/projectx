using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : ScriptableObject
{
    private string playerPrefsScore;

    public Score(string playerPrefsScore)
    {
        this.playerPrefsScore = playerPrefsScore;
    }

    public void SetValue(int score)
    {
        Debug.Log(playerPrefsScore + ": " + score);
        PlayerPrefs.SetInt(playerPrefsScore, score);
    }

    public int GetValue()
    {
        return PlayerPrefs.GetInt(playerPrefsScore, 0);
    }
}
