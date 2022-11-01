using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodtest2 : MonoBehaviour
{
    [FMODUnity.ParamRef]
    public string paramaterName;

    public string para;

    public void OnClick()
    {
        SoundManager.Instance.change_SE(paramaterName, para);
    }
}
