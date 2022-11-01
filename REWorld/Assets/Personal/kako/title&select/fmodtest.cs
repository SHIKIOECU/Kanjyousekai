using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodtest : MonoBehaviour
{
    public FMODUnity.EventReference m_EventRef;

    public void OnClick()
    {
        SoundManager.Instance.PlaySE(m_EventRef);
    }
}
