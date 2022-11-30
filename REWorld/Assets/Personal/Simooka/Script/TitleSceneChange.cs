using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneChange : MonoBehaviour
{
    [Header("タイトルキャンバス"),SerializeField] private GameObject _title;
    [Header("ステージセレクトキャンバス"),SerializeField] private GameObject _select;

    public void OnStart()
    {
        _title.SetActive(false);
        _select.SetActive(true);
    }
}
