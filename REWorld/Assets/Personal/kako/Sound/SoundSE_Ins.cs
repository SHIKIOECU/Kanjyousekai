using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSE_Ins : MonoBehaviour
{

    public SoundManagerA.SE_List SE_number;

    public void OnClick()
    {
        SoundManagerA.Instance.PlaySE(SE_number);
    }
}
