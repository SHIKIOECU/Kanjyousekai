using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/NPC/NPCData")]
public class NPCData : ScriptableObject
{
    //NPCデータ
    public NPCState Data = new NPCState();

    //NPCの共通データリスト
    [SerializeField]
    private List<NPCState> npcStates = new List<NPCState>();
    public List<NPCState> NPCStates { get { return npcStates; } }

    //private void Awake()
    //{
    //    Data = npcStates[0];
    //    InitNPCFlag();
    //    Debug.Log("!!");
    //}


    //NPCのフラグを初期化
    public void InitNPCFlag()
    {
        foreach(NPCState npc in npcStates)
        {
            npc.NPCFlag.InitFlag();
        }
        SetFlag("basic");
    }

    //NPCのフラグを変更する
    public void SetFlag(string name, bool value = true)
    {
        foreach (NPCState npc in npcStates)
        {
            if (npc.Name == name)
            {
                //フラグをOnにした時Dataを更新
                if (value)
                {
                    Data.NPCFlag.SetFlagStatus(false);
                    Data = npc;
                }
                npc.NPCFlag.SetFlagStatus(value);
                return;
            }
        }
    }

    //NPCのフラグを参照する
    public bool GetFlagStatus(FlagData flag)
    {
        foreach (NPCState npc in npcStates)
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
    public FlagData NPCFlag;
}