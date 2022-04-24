using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUI : MonoBehaviour
{
    [SerializeField] GameObject soundOnObject;
    [SerializeField] GameObject soundOffObject;

    AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        if (PlayerPrefs.HasKey(Globals.SOUND_KEY))
        {
            bool soundOn = PlayerPrefs.GetInt(Globals.SOUND_KEY) == 1 ? true : false;
            Globals.Instance.SetSound(soundOn, audioSources, soundOnObject, soundOffObject);
        }
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
