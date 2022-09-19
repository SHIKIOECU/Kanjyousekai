using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detective : MonoBehaviour,INPC
{
    //感情世界
    [SerializeField]
    private GameObject _emotionalWorld;

    //感情世界のグラフィック
    [SerializeField]
    private List<Sprite> _emotionalWorldSprites;

    //グラフィック
    [SerializeField]
    private SpriteRenderer _NPC;

    //セリフ
    [SerializeField]
    private Text _words;

    //セリフテキスト
    [SerializeField]
    private List<string> _wordsText;

    //NPC状態フラグ
    [SerializeField]
    private List<FlagData> _flag;

    //アイテム（コイン）フラグ
    [SerializeField]
    private FlagData _coin;

    //フラグを全てfalseにする
    void FlagReset()
    {
        for (int i = 0; i < _flag.Count; i++)
        {
            _flag[i].InitFlag();
        }
    }

    //インターフェースを実装
    public GameObject EmotionalWorld => _emotionalWorld;

    public List<Sprite> EmotionalWorldSprite => _emotionalWorldSprites;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => _words;

    public List<string> WordsText => _wordsText;

    public List<FlagData> FlagDatas => _flag;

    //感情世界の画像を変更
    public void ChangeWorld()
    {
        for (int i = 0; i < _flag.Count; i++)
        {
            if (FlagDatas[i].IsOn)
            {
                EmotionalWorld.GetComponent<SpriteRenderer>().sprite = EmotionalWorldSprite[i];
                Debug.Log("ChangeWorld");
                break;
            }
        }
    }

    public void SetActiveWorld()
    {
        EmotionalWorld.SetActive(true);
    }
}
