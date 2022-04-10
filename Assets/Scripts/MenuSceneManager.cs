using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] GameObject soundOnObject;
    [SerializeField] GameObject soundOffObject;

    AudioSource[] audioSources;

    private void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        Debug.Log(audioSources.Length);

        if (PlayerPrefs.HasKey(Globals.SOUND_KEY))
        {
            bool soundOn = PlayerPrefs.GetInt(Globals.SOUND_KEY) == 1 ? true : false;
            Globals.Instance.SetSound(soundOn, audioSources, soundOnObject, soundOffObject);
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
