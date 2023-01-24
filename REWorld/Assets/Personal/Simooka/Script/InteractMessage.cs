using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMessage : MonoBehaviour
{
    #region public変数
    [Header("インタラクト文")]
    public string Message;
    public Vector2 Space;
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
