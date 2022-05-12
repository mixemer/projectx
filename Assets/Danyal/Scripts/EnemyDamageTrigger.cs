using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamageTrigger : MonoBehaviour
{

    private Player player;
    private LevelManager levelManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Enemy"))
        {
            player.Kill();
            levelManager.LoadGaveOverScene();
        }
    }

    private void EndScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
