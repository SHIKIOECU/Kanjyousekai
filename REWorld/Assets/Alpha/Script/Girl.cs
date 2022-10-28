using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Girl : MonoBehaviour,INPC,IItem
{
    //NPCData
    [SerializeField]
    private NPCData NData;

    //感情世界
    [SerializeField]
    private GameObject _emotionalWorld;

    //グラフィック
    [SerializeField]
    private SpriteRenderer _NPC;

    //セリフ
    [SerializeField]
    private Text _words;

    //セリフテキスト
    [SerializeField]
    private List<string> _wordsText;

    //アイテム（アイス）フラグ
    [SerializeField]
    private FlagData iceFlag;

    //探偵
    [SerializeField]
    private Detective detective;

    //虹
    [SerializeField]
    private GameObject _rainbow;

    public bool _getIce;

    //アニメーター
    private Animator _animator;

    private void Start()
    {
        EmotionalWorld.SetActive(false);
        INPCData.InitNPCFlag();
        //_animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    //インターフェースの定義
    public NPCData INPCData => NData;

    public GameObject EmotionalWorld => _emotionalWorld;

    public Sprite EmotionalWorldSprite => NData.Data.EmotionalWorldSprite;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => _words;

    public List<string> WordsText => _wordsText;

    public void AppearanceWorld()
    {
        //感情世界を出現させる
        EmotionalWorld.SetActive(true);

        switch (INPCData.Data.Name)
        {
            //泣いている場合（基本）
            case "basic":
                detective.INPCData.SetFlag("move");
                detective.isSetPos = false;
                detective.moved = false;
                break;
            //喜んでいる場合
            case "happy":
                _rainbow.SetActive(true);
                break;

        }
    }
  
    public void ChangeWorld()
    {
        //感情世界の画像を変更
        EmotionalWorld.GetComponent<SpriteRenderer>().sprite
            = EmotionalWorldSprite;
    }

    public void DisappearanceWorld()
    {
        EmotionalWorld.SetActive(false);
        detective.INPCData.SetFlag("basic");
        detective.moved = false;
    }

    public void ItemAction()
    {
        //iceFlagを参照してフラグを切り替える
        if (iceFlag.IsOn)
        {
            _getIce = true;
            iceFlag.SetFlagStatus(false);
            INPCData.SetFlag("happy");

            ChangeWorld();
        }

    }

    
}
