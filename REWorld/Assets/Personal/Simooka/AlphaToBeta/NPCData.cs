using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/NPC/NPCData")]
public class NPCData : ScriptableObject
{
    public List<NPCState> NPCStates;

    public enum State
    {
        Basic,
        ChangeWorld,
    }

    public State state;

    public void ChangeWorld()
    {
        switch (state)
        {
            case State.Basic:
                break;
            case State.ChangeWorld:
                break;
        }
    }
}

[System.Serializable]
public class NPCState
{
    public string Name;
    public Sprite EmotionalWorldSprite;
    public Text Words;
}