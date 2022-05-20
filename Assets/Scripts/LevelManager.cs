using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Delay Between Loading Scenes")]
    [Space(10)]
    [SerializeField] float sceneLoadDelay = .25f;
    [SerializeField] float gameoverLoadDelay = 2f;

    public void LoadGameScene()
    {
        StartCoroutine(WaitAndLoad("GameScene", sceneLoadDelay));
    }

    public void LoadCharacterSelectionScene()
    {
        StartCoroutine(WaitAndLoad("CharacterSelectionScene", sceneLoadDelay));
    }

    public void LoadMainMenuScene()
    {
        StartCoroutine(WaitAndLoad("MainMenuScene", sceneLoadDelay));
    }
    
    public void LoadHighScoreScene()
    {
        StartCoroutine(WaitAndLoad("HighScoreScene", sceneLoadDelay));
    }

    public void LoadMainMenuSceneNoDelay()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void LoadGaveOverScene()
    {
        StartCoroutine(WaitAndLoad("GameOverScene", gameoverLoadDelay));
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
