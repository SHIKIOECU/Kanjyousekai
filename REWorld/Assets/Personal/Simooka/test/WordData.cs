using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "ScriptableObject/NPC/WordData")]
public class WordData : ScriptableObject
{
    public List<WordState> WordStates; 

}

[System.Serializable]
public struct WordState
{
    public string Name;
    public Vector2 TextBoxSize;
    public float FontSize;
}
