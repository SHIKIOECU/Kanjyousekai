using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins_SoundSE : MonoBehaviour
{
    public int SEnumber = 0;

    private void Start()
    {
        SoundManager.instance.PlaySE(SEnumber);
    }
}
