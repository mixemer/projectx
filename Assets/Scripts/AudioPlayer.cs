using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("UI Sounds")]
    [SerializeField] AudioClip buttonClickClip;
    [SerializeField] [Range(0f, 1f)] float buttonClickVolume = 1f;

    [Header("Game Audio")]
    [SerializeField] AudioClip foodEatClip;
    [SerializeField] [Range(0f, 1f)] float foodEatVolume = 1f;
    [Space(10)]
    [SerializeField] AudioClip trashEatClip;
    [SerializeField] [Range(0f, 1f)] float trashEatVolume = 1f;
    [Space(10)]
    [SerializeField] AudioClip healthCriticalClip;
    [SerializeField] [Range(0f, 1f)] float healthCriticalVolume = 1f;
    [Space(10)]
    [SerializeField] AudioClip toxinContactClip;
    [SerializeField] [Range(0f, 1f)] float toxinContactVolume = 1f;

    /* Shared AudioPlayer Throughout Different Scenes */
    static AudioPlayer instance;

    private void Awake()
    {
        LoadAudioPlayer();
    }

    private void LoadAudioPlayer()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }

    public void PlayButtonClick()
    {
        PlaySound(buttonClickClip, buttonClickVolume);
    }

    public void PlayFoodEat()
    {
        PlaySound(foodEatClip, foodEatVolume);
    }

    public void PlayTrashEat()
    {
        PlaySound(trashEatClip, trashEatVolume);
    }

    public void PlayHealthCritical()
    {
        PlaySound(healthCriticalClip, healthCriticalVolume);
    }

    public void PlayToxinContact()
    {
        PlaySound(toxinContactClip, toxinContactVolume);
    }
}
