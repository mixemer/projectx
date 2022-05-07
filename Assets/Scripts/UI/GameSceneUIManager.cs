using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUIManager : MonoBehaviour
{
    [SerializeField] GameObject soundOnObject;
    [SerializeField] GameObject soundOffObject;

    AudioSource[] audioSources;

    private void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();

        if (PlayerPrefs.HasKey(Globals.SOUND_KEY))
        {
            bool soundOn = PlayerPrefs.GetInt(Globals.SOUND_KEY) == 1 ? true : false;
            Globals.Instance.SetSound(soundOn, audioSources, soundOnObject, soundOffObject);
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Globals.Instance.FreezeGame();
    }
    public void ResumeGame()
    {
        Globals.Instance.UnFreezeGame();
    }


    public void SoundOn()
    {
        Globals.Instance.SetSound(true, audioSources, soundOnObject, soundOffObject);
    }

    public void SoundOff()
    {
        Globals.Instance.SetSound(false, audioSources, soundOnObject, soundOffObject);
    }
}
