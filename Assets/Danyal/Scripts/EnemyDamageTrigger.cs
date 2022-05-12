using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamageTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Enemy"))
        {
            EndScene();
        }
    }

    private void EndScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
