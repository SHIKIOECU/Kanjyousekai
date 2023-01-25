using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMessage : MonoBehaviour
{
    #region public変数
    [Header("インタラクト情報")]
    public string Message;
    public Sprite ButtonSprite;
    [System.NonSerialized]public Vector2 Space;
    #endregion

    void Awake()
    {
        Space = transform.position;
    }

    public void ChangeInteractMessage(string word)
    {
        Message = word;
    }
}
