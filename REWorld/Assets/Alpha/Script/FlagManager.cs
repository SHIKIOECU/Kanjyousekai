using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public static FlagManager instance;

    [SerializeField]
    private List<FlagUnit> _flag = new List<FlagUnit>();

    private void Reset()
    {
        instance = this;
    }

    private void Start()
    {
        instance = this;
    }

    public void AddFlag(string name,GameObject gameObject,bool flag)
    {
        FlagUnit flagUnit = new FlagUnit();
        flagUnit.name = name;
        //flagUnit._unit = gameObject;
        flagUnit.flag = flag;
        _flag.Add(flagUnit);
    }

    public void OnFlag(string name,bool flag)
    {
        for(int i = 0; i < _flag.Count; i++)
        {
            if (_flag[i].name == name)
            {
                FlagUnit Data = _flag[i];
                Data.flag = flag;
                _flag[i] = Data;
                break;
            }
        }
    }
}
