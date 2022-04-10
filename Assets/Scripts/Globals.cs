using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals Instance;

    public const string SOUND_KEY = "sound_on";

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
}
