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
        stageBGM[0] = FrontBGM;
        stageBGM[1] = BackBGM;

        sounds[stageBGM[0]].Play();
        sounds[stageBGM[1]].Play();

        sounds[stageBGM[1]].mute = true;
    }

    //trueの方が音消える
    public void ChangeBGM(bool FrontBGMTF)
    {
        try
        {
            sounds[0].mute = FrontBGMTF;
            sounds[1].mute = !(FrontBGMTF);
        }catch (System.IndexOutOfRangeException IE)
        {
            Debug.Log("曲がないよ");
        }
    }

    public void ChangeBGM(int FrontBGMN)
    {
        try
        {
            sounds[FrontBGMN].mute = false;
            for (int i = 0; i < BGMLength; i++)
            {
                sounds[FrontBGMN].mute = true;
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
        }catch(System.IndexOutOfRangeException IE)
        {
            Debug.Log("曲がないよ");
        }
    }

    public void stageBGMstop()
    {
        try { 
            sounds[stageBGM[0]].Stop();
            sounds[stageBGM[1]].Stop();
        }
        catch (System.IndexOutOfRangeException IE)
        {
            Debug.Log("曲がないよ");
        }
    }
}
