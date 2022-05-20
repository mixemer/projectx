using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private AudioSource source;
    public AudioClip foodSound;
    public AudioClip trashSound;
    public AudioClip killedSound;


    private void Awake()
    {
        source = FindObjectOfType<AudioSource>();
    }

    public void playFood()
    {
        source.PlayOneShot(foodSound);
    }
    
    public void playTrash()
    {
        source.PlayOneShot(trashSound);
    }
    
    public void playKilled()
    {
        source.PlayOneShot(killedSound);
    }
}
