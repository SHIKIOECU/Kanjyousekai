using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface INPC 
{
    GameObject EmotionalWorld { get; }
    List<Sprite> EmotionalWorldSprite { get; }
    SpriteRenderer NPCSprite { get; }
    Text Words { get; }
    List<string> WordsText { get; }
    List<FlagData> FlagDatas { get; }
    //List<FlagUnit> Flag { get; }

    void SetActiveWorld();
    void ChangeWorld();
}

[System.Serializable]
public struct FlagUnit
{
    public string name;
    //public GameObject _unit;
    public bool flag;
}