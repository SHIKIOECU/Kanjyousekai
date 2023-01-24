using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class playerWalk_Sound : MonoBehaviour
{
    public static playerWalk_Sound InstanceWalk;

    public enum WalkSE_List
    {
        HardFloor,
        Glass,
        Rain,
        Sand,
        Soil,
        Snow
    }

    public AudioClip[] LandSEClips = new AudioClip[6];
    public SEClips[] WalkSEClips;

    [SerializeField] private float timeInterval;
    private float timeElapsed;

    AudioSource[] sounds;

    public WalkSE_List WalkSE_num = WalkSE_List.HardFloor;
    public bool walkTF = false;

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

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        OnMove();
        if (walkTF)
        {
            if (timeElapsed > timeInterval)
            {
                PlaySE_Walk();
                // 経過時間を元に戻す
                timeElapsed = 0f;
            }
        }
        
    }

    public void OnMove()
    {
        if(Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed ||
            Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            walkTF = true;
        }
        else
        {
            walkTF = false;
        }
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

    public void PlaySE_Walk()
    {
        if (WalkSEClips[(int)WalkSE_num].walkSEClips[(int)Random.RandomRange(0, WalkSEClips[(int)WalkSE_num].walkSEClips.Length)] != null)
        {
            try
            {
                sounds[0].PlayOneShot(WalkSEClips[(int)WalkSE_num].walkSEClips[(int)Random.RandomRange(0, WalkSEClips[(int)WalkSE_num].walkSEClips.Length)]);
            }
            catch (System.NullReferenceException NE)
            {
                Debug.Log("音を入れろ");
            }
        }
    }

    public void WalkSE_Change(WalkSE_List SElist)
    {
        WalkSE_num = SElist;
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
