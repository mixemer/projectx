using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameObject EndGamePanel;
    public Player player;

    // After this game will be unlivable. in minutes
    public int GameTimer = 3;
    // in seconds
    public float RemaininTimerSeconds;

    float start;
    float mid;

    public GameStage gameStage;

    private LevelManager levelManager;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        EndGamePanel.SetActive(false);
        RemaininTimerSeconds = GameTimer * 60;

        int GameTimerSeconds = GameTimer * 60;

        start = GameTimerSeconds - GameTimerSeconds / 3;
        mid = GameTimerSeconds - GameTimerSeconds / 3 - GameTimerSeconds / 3;
    }

    void Update()
    {
        RemaininTimerSeconds -= Time.deltaTime;
        GetGameStage();
        if (player.HealthIsBelowMinimum())
        {
            levelManager.LoadGaveOverScene();
            if (player.IsAlive())
            {
                player.Kill();
            }
        }
    }

    public enum GameStage
    {
        Starting, Mid, Ending
    }

    public GameStage GetGameStage()
    {
        if (RemaininTimerSeconds < mid)
        {
            gameStage = GameStage.Ending;
            return GameStage.Ending;
        } else if (RemaininTimerSeconds < start)
        {
            gameStage = GameStage.Mid;
            return GameStage.Mid;
        }
        else
        {
            gameStage = GameStage.Starting;
            return GameStage.Starting;
        }
    }
}
