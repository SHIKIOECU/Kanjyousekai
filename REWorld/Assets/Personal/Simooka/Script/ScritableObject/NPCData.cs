using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/NPC/NPCData")]
public class NPCData : ScriptableObject
{
    [SerializeField, Header("通常時のセリフ")]
    private List<NPCWord> _normalWords = new List<NPCWord>();
    public List<NPCWord> NormalWords { get { return _normalWords; } }

    [SerializeField,Header("観測時の状態")]
    private List<NPCState> _observationalWorld = new List<NPCState>();
    public List<NPCState> ObservationalWorld { get { return _observationalWorld; } }


    //NPCのフラグを参照する
    //public bool GetFlagStatus(FlagData flag)
    //{
    //    foreach (NPCState npc in _observationalWorld)
    //    {
    //        if (npc.NPCFlag == flag)
    //        {
    //            return npc.NPCFlag.IsOn;
    //        }
    //    }
    //    return false;
    //}
}

//NPCの観測時データ
[System.Serializable]
public struct NPCState
{
    [Tooltip("名前")]public string Name;
    [Tooltip("背景")] public Sprite EmotionalWorldSprite; 
    [Tooltip("セリフ")] public string Word;                
    //[Tooltip("フラグ")] public FlagData NPCFlag;            
}

//NPCの通常時のセリフデータ
[System.Serializable]
public struct NPCWord
{
    [Tooltip("状態")] public string Faze; 
    [Tooltip("セリフ")] public string Word; 
}