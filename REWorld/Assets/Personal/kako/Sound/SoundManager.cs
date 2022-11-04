using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private static FMOD.Studio.EventInstance Music;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void change_SE(string ParamaterName ,string para_label)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByNameWithLabel(ParamaterName, para_label);
    }

    public void PlaySE(FMODUnity.EventReference m_EventRef)
    {
        FMODUnity.RuntimeManager.PlayOneShot(m_EventRef);
    }

    public void PlaySE(string m_EventRef)
    {
        FMODUnity.RuntimeManager.PlayOneShot(m_EventRef);
    }

    //ここは後々
    public void PlayBGM(string m_EventRef)
    {
        Music = FMODUnity.RuntimeManager.CreateInstance(m_EventRef);
        Music.start();
        Music.release();
        //return Music;
    }

    public void PlayStageBGM(int FrontBGM, int BackBGM)
    {
        
    }

    //trueの方が音消える
    public void DeleteBGM(FMOD.Studio.EventInstance music_ins)
    {
        music_ins.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void stopBGM(int BGMnumber)
    {
        //sounds[BGMnumber].Stop();
    }

    public void stageBGMstop()
    {
        //sounds[stageBGM[0]].Stop();
        //sounds[stageBGM[1]].Stop();
    }
}
