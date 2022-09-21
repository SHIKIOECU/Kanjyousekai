using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins_Sound : MonoBehaviour
{
    public AudioClip[] Clips = new AudioClip[2];

    AudioSource[] sounds;

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        PlaySound();
    }

    public void PlaySound()
    {
        sounds[0].Play();
    }
}
