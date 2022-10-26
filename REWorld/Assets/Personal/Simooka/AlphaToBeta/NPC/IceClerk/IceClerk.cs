using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceClerk : MonoBehaviour,INPC,IItem
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

    //アイス
    [SerializeField]
    private Ice ice;
    //アイテムフラグ（アイス）
    [SerializeField]
    private FlagData iceFlag;

    //投げる速度
    [SerializeField]
    private float _slowSpeed;

    //アイテムフラグ（コイン）
    [SerializeField]
    private FlagData coin;


    //アニメーター
    private Animator _animator;

    //ジャンプできるようになったかどうか
    public bool _jumping = false;

    //上昇したジャンプ力
    [SerializeField]
    private float jumpPowerUp;

    private void Start()
    {
        EmotionalWorld.SetActive(false);
        INPCData.InitNPCFlag();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!EmotionalWorld.active)
        {
            PlayerMove.instance.jumpPower = PlayerMove.instance.basicJumpPower;
        }
    }

    //インターフェースの定義
    public NPCData INPCData => NData;

    public GameObject EmotionalWorld => _emotionalWorld;

    public Sprite EmotionalWorldSprite => NData.Data.EmotionalWorldSprite;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => _words;

    public List<string> WordsText => _wordsText;

    public void SetActiveWorld()
    {
        //感情世界を出現させる
        EmotionalWorld.SetActive(true);

        switch (INPCData.Data.Name)
        {
            //アイスが売れていない場合（基本）
            case "basic":
                ice.gameObject.SetActive(true);
                ice.Rb2D.velocity = new Vector2(_slowSpeed, 0);
                _animator.SetBool("throwTrigger", true);
                break;
            //喜んでいる場合
            case "happy":
                _jumping = true;
                ice.gameObject.SetActive(false);
                PlayerMove.instance.jumpPower = jumpPowerUp;
                break;

        }
    }

    public void ChangeWorld()
    {
        //感情世界の画像を変更
        EmotionalWorld.GetComponent<SpriteRenderer>().sprite
            = EmotionalWorldSprite;
    }

    public void ItemAction()
    {
        //Coinを参照してフラグを切り替える
        if (coin.IsOn)
        {
            coin.InitFlag();
            iceFlag.SetFlagStatus();

            INPCData.SetFlag("happy");

            ChangeWorld();

            //仮
            //if (_flag[1].IsOn)
            //{
            //    _jumping = true;
            //    ice.gameObject.SetActive(false);
            //    PlayerMove.instance.jumpPower = jumpPowerUp;
            //}
        }

    }
}
