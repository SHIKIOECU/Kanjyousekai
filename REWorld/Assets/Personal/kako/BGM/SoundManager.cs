using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    public static int NowBGM = 1;

    public AudioClip[] SEClips = new AudioClip[6];
    public AudioClip[] BGMClips = new AudioClip[4];
        
    AudioSource[] sounds;

    private int[] stageBGM = new int[2];

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        //PlaySound();
    }

    public void PlaySE(int SEnumber)
    {
        sounds[0].PlayOneShot(SEClips[SEnumber]);
    }

    public void PlayBGM(int BGMnumber)
    {
        sounds[BGMnumber].Play();
    }

    public void PlayStageBGM(int FrontBGM, int BackBGM)
    {
        stageBGM[0] = FrontBGM;
        stageBGM[1] = BackBGM;

        sounds[stageBGM[0]].Play();
        sounds[stageBGM[1]].Play();

        sounds[stageBGM[1]].mute = true;
    }

    //trueの方が音消える
    public void ChangeBGM(bool FrontBGMTF)
    {
        sounds[stageBGM[0]].mute = FrontBGMTF;
        sounds[stageBGM[1]].mute = !(FrontBGMTF);
    }

    public void stopBGM(int BGMnumber)
    {
        sounds[BGMnumber].Stop();
    }

    public void stageBGMstop()
    {
        sounds[stageBGM[0]].Stop();
        sounds[stageBGM[1]].Stop();
    }
}
