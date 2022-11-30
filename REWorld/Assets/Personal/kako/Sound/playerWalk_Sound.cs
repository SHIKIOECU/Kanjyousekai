using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWalk_Sound : MonoBehaviour
{
    public static playerWalk_Sound InstanceWalk;

    public enum WalkSE_List
    {
        HardFloor,
        Glass,
        Soil,
        Rain,
        Sand,
        Snow
    }

    public AudioClip[] LandSEClips = new AudioClip[6];
    public SEClips[] WalkSEClips;

    AudioSource[] sounds;

    private void Awake()
    {
        if (InstanceWalk == null)
        {
            InstanceWalk = this;
        }
    }

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        //PlaySound();
    }

    [System.Obsolete]
    public void PlaySE_Walk(WalkSE_List SEnumber)
    {
        if (WalkSEClips[(int)SEnumber].walkSEClips[(int)Random.RandomRange(0, WalkSEClips[(int)SEnumber].walkSEClips.Length)] != null)
        {
            try
            {
                sounds[0].PlayOneShot(WalkSEClips[(int)SEnumber].walkSEClips[(int)Random.RandomRange(0, WalkSEClips[(int)SEnumber].walkSEClips.Length)]);
            }
            catch (System.NullReferenceException NE)
            {
                Debug.Log("音を入れろ");
            }
        }
    }

    public void PlaySE_Land(WalkSE_List SEnumber)
    {
        if (LandSEClips[(int)SEnumber] != null)
        {
            try
            {
                sounds[0].PlayOneShot(LandSEClips[(int)SEnumber]);
            }
            catch (System.NullReferenceException NE)
            {
                Debug.Log("音を入れろ");
            }
        }
    }
}

[System.Serializable]
public class SEClips
{
    public AudioClip[] walkSEClips;
}
