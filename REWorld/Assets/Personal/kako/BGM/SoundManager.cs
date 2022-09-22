using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    public AudioClip[] Clips = new AudioClip[2];
        
    AudioSource[] sounds;

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        //PlaySound();
    }

    public void PlaySound(AudioClip audioClip)
    {
        sounds[0].PlayOneShot(audioClip);
    }
}
