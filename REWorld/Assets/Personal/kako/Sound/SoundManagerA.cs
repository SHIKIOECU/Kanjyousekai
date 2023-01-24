using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerA : MonoBehaviour
{

    public static SoundManagerA Instance;

    public int BGMLength = 1;



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

    public enum BGM_List
    {
        SE,
        Normal,
        Sad,
        Happy,
        Angry,
        option1,
        option2,
        option3,
        option4
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
        sounds = transform.parent.GetComponents<AudioSource>();
        //PlaySound();
    }

    public void PlaySE(SE_List SEnumber)
    {
        if (SEClips[(int)SEnumber] != null)
        {
            try
            {
                sounds[0].PlayOneShot(SEClips[(int)SEnumber]);
            }
            catch (System.NullReferenceException NE)
            {
                Debug.Log("音を入れろ");
            }
        }
    }

    public void PlaySE(AudioClip SEnumber)
    {
        sounds[0].PlayOneShot(SEnumber);
    }

    public void PlayBGM(int BGMnumber)
    {
        try
        {
            sounds[BGMnumber].Play();
        }catch (System.IndexOutOfRangeException IE)
        {
            Debug.Log("曲がないよ");
        }
    }

    public void PlayStageBGM(int FrontBGM, int BackBGM)
    {
        stageBGM[1] = FrontBGM;
        stageBGM[2] = BackBGM;

        sounds[stageBGM[1]].Play();
        sounds[stageBGM[2]].Play();

        sounds[stageBGM[2]].mute = true;
    }

    //trueの方が音消える
    public void ChangeBGM(bool FrontBGMTF)
    {
        try
        {
            sounds[1].mute = FrontBGMTF;
            sounds[2].mute = !(FrontBGMTF);
        }catch (System.IndexOutOfRangeException IE)
        {
            Debug.Log("曲がないよ");
        }
    }

    public void ChangeBGM(BGM_List FrontBGMN)
    {
        try
        {
            for (int i = 1; i < BGMLength + 1; i++)
            {
                sounds[i].mute = true;
            }
            sounds[(int)FrontBGMN].mute = false;

            if((int)FrontBGMN == 1)
            {
                sounds[0].mute = true;
            }
            else
            {
                sounds[0].mute = false;
            }
        }
        catch (System.IndexOutOfRangeException IE)
        {
            Debug.Log("曲がないよ");
        }
    }

    public void stopBGM(int BGMnumber)
    {
        try
        {
            sounds[BGMnumber].Stop();
        }
        catch(System.IndexOutOfRangeException IE)
        {
            Debug.Log("曲がないよ");
        }
    }

    public void stageBGMstop()
    {
        try {
            for (int i = 1; i < BGMLength + 1; i++)
            {
                sounds[i].Stop();
            }
        }
        catch (System.IndexOutOfRangeException IE)
        {
            Debug.Log("曲がないよ");
        }
    }
}
