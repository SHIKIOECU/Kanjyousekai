using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins_SoundSE : MonoBehaviour
{
    public AudioClip[] Clips = new AudioClip[2];

    AudioSource[] sounds;

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        
        //PlaySound();
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    PlaySound(Clips[0]);
        //}
        //if (Input.GetKey(KeyCode.RightShift))
        //{
        //    PlaySound(Clips[1]);
        //}
    }

    public void PlaySound(AudioClip audioClip)
    {
        sounds[0].PlayOneShot(audioClip);
    }
}
