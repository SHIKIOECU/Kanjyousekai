using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/NPC/NPCData")]
public class NPCData : ScriptableObject
{
    //NPCデータ
    //public NPCState Data = new NPCState();

    //NPCの共通データリスト
    [SerializeField]
    private List<NPCState> _npcStates = new List<NPCState>();
    public List<NPCState> NPCStates { get { return _npcStates; } }


    public List<NPCWord> Words = new List<NPCWord>();


    //NPCのフラグを初期化
    //public void InitNPCFlag()
    //{
    //    foreach(NPCState npc in _npcStates)
    //    {
    //        npc.NPCFlag.InitFlag();
    //    }
    //}

    //NPCのフラグを変更する
    //public void SetFlag(string name, bool value = true)
    //{
    //    foreach (NPCState npc in _npcStates)
    //    {
    //        if (npc.Name == name)
    //        {
    //            //フラグをOnにした時Dataを更新
    //            if (value)
    //            {
    //                Data.NPCFlag.SetFlagStatus(false);
    //                Data = npc;
    //            }
    //            npc.NPCFlag.SetFlagStatus(value);
    //            return;
    //        }
    //    }
    //}

    //NPCのフラグを参照する
    public bool GetFlagStatus(FlagData flag)
    {
        foreach (NPCState npc in _npcStates)
        {
            if (npc.NPCFlag == flag)
            {
                return npc.NPCFlag.IsOn;
            }
        }
        return false;
    }
}

//NPCの共通データ
[System.Serializable]
public struct NPCState
{
    public string Name;
    public Sprite EmotionalWorldSprite;
    public string Word;
    public FlagData NPCFlag;
}

[System.Serializable]
public struct NPCWord
{
    public string Faze;
    public string Word;
    public List<Term> Terms;
}

[System.Serializable]
public struct Term
{
    public FlagData FlagData;
    public bool IsCheck;
}