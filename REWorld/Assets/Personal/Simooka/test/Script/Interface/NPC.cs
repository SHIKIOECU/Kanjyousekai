using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface INPC 
{
    //NPCのデータ
    NPCData INPCData { get; }

    //感情世界
    GameObject EmotionalWorld { get; }

    //感情世界のグラフィック
    Sprite EmotionalWorldSprite { get; }

    //NPCのグラフィック
    SpriteRenderer NPCSprite { get; }

    //セリフ
    //TextMeshPro Words { get; }

    ////セリフ内容
    //List<string> WordsText { get; }

    //List<FlagData> FlagDatas { get; }

    //世界を出現させる
    void AppearanceWorld();

    //感情世界を変更
    void ChangeWorld();

    //世界を消失させる
    void DisappearanceWorld();
}