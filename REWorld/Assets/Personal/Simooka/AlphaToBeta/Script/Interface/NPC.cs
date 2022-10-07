using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface INPC 
{
    //感情世界
    GameObject EmotionalWorld { get; }

    //感情世界のグラフィック
    Sprite EmotionalWorldSprite { get; }

    //NPCのグラフィック
    SpriteRenderer NPCSprite { get; }

    //セリフ
    Text Words { get; }

    //セリフ内容
    List<string> WordsText { get; }

    //List<FlagData> FlagDatas { get; }

    //観測した時
    void SetActiveWorld();

    //感情世界を変更
    void ChangeWorld();
}