using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMessage : MonoBehaviour
{
    #region public変数
    [Header("インタラクト情報")]
    public string NPCMessage;
    public Sprite NPCButtonSprite;
    public string ItemMessage;
    public Sprite ItemButtonSprite;
    [HideInInspector]public Vector2 Space;
    #endregion

    void Awake()
    {
        Space = transform.position;
    }

    public void ChangeInteractMessage(string word)
    {
        //Message = word;
    }
}
