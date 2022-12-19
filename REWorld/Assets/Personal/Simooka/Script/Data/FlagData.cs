using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New FlagData",menuName ="ScriptableObject/Flags/FlagData")]
public class FlagData : ScriptableObject
{
    [SerializeField]
    bool isOn = false;

    public bool IsOn { get { return isOn; } }

    public void InitFlag()
    {
        isOn = false;
    }

    public void SetFlagStatus(bool value = true)
    {
        isOn = value;
    }
}
