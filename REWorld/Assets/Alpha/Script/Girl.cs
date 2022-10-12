using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Girl : MonoBehaviour,IItem
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
    private FlagData _ice;

    [SerializeField]
    private FlagData _detective;

    [SerializeField]
    private Detective detective;

    [SerializeField]
    private GameObject _gimmick;

    [SerializeField]
    private List<GameObject> _gimmickList;

    public bool getIce;

    //アニメーター
    private Animator animator;

    private void Start()
    {
        EmotionalWorld.SetActive(false);
        NData.InitNPCFlag();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!EmotionalWorld.active)
        {
            _detective.SetFlagStatus(false);
            detective.isSetPos = false;
        }
    }

    //インターフェースの定義
    public GameObject EmotionalWorld => _emotionalWorld;

    public Sprite EmotionalWorldSprite => NData.Data.EmotionalWorldSprite;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => _words;

    public List<string> WordsText => _wordsText;

    public void SetActiveWorld()
    {
        EmotionalWorld.SetActive(true);

        switch (NData.Data.Name)
        {
            case "basic":
                _detective.SetFlagStatus();
                detective.isSetPos = false;
                break;
            case "happy":
                _gimmick.SetActive(true);
                break;

        }
        //if (_gimmick != null)
        //{
        //    _gimmick.SetActive(true);
        //}

        //if (FlagDatas[0].IsOn)
        //{
        //    _detective.SetFlagStatus();
        //    detective.isSetPos = false;
        //}
       

        detective.moved = false;
    }

    //感情世界の画像を変更
    public void ChangeWorld()
    {
        EmotionalWorld.GetComponent<SpriteRenderer>().sprite
            = EmotionalWorldSprite;
    }

    //ItemListを参照してフラグを切り替える
    public void ItemAction()
    {
        if (_ice.IsOn)
        {
            getIce = true;
            _ice.InitFlag();
            NData.SetFlag("happy");

            _gimmick = _gimmickList[0];
            ChangeWorld();
        }

    }

    
}
