using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUIManager : MonoBehaviour
{
    [SerializeField] AudioListener audiolistener;

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }


    // TODO: Add PlayerPrefs
    public void SoundOn()
    {
        audiolistener.enabled = true;
    }

    // TODO: Add PlayerPrefs
    public void SoundOff()
    {
        audiolistener.enabled = false;
    }
}
