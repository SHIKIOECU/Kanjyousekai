using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerA : MonoBehaviour
{

    public static SoundManagerA Instance;

    public static int NowBGM = 1;

    public enum SE_List
    {
        Open_World,
        Close_World,
        Intract_Success,
        Intract_Failed,
        Get_Item,

        Stage_Start,
        Stage_Clear,
        Select_Stage,
        Botton_Positive,
        Botton_Negative,

        Ice_Throw,
        Ice_Wall,
        Rainbow
    }

    public AudioClip[] SEClips = new AudioClip[13];
        
    AudioSource[] sounds;

    private int[] stageBGM = new int[2];

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        //PlaySound();
    }

    public void PlaySE(SE_List SEnumber)
    {
        sounds[0].PlayOneShot(SEClips[(int)SEnumber]);
    }

    public void PlaySE_A(AudioClip SEnumber)
    {
        sounds[2].PlayOneShot(SEnumber);
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
        sounds[0].mute = FrontBGMTF;
        sounds[1].mute = !(FrontBGMTF);
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
