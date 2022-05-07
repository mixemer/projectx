using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals Instance;

    public const string SOUND_KEY = "sound_on";

    public const string coralAliveDetails = "";
    public const string coralDeadDetails = "";

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSound(bool val, AudioSource[] audioSources, GameObject soundOnObject, GameObject soundOffObject)
    {
        foreach (AudioSource source in audioSources)
        {
            source.enabled = val;
        }

        soundOnObject.SetActive(val);
        soundOffObject.SetActive(!val);

        PlayerPrefs.SetInt(SOUND_KEY, val ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void FreezeGame()
    {
        Time.timeScale = 0;
    }

    public void UnFreezeGame()
    {
        Time.timeScale = 1;
    }
}
