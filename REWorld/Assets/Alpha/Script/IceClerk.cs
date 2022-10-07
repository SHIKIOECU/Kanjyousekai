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
    private FlagData _ice;

    //投げる速度
    [SerializeField]
    private float slowSpeed;

    //アイテムフラグ（コイン）
    [SerializeField]
    private FlagData _coin;


    //アニメーター
    private Animator animator;

    //ジャンプできるようになったかどうか
    public bool jumping = false;

    //上昇したジャンプ力
    [SerializeField]
    private float jumpPowerUp;

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
            PlayerMove.instance.jumpPower = PlayerMove.instance.basicJumpPower;
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
                ice.gameObject.SetActive(true);
                ice.Rb2D.velocity = new Vector2(slowSpeed, 0);
                //アニメーターの設定
                animator.SetBool("throwTrigger", true);
                break;
            case "happy":
                jumping = true;
                ice.gameObject.SetActive(false);
                PlayerMove.instance.jumpPower = jumpPowerUp;
                break;

        }
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
        if (_coin.IsOn)
        {
            _coin.InitFlag();
            _ice.SetFlagStatus();

            NData.SetFlag("happy");

            ChangeWorld();

            //仮
            //if (_flag[1].IsOn)
            //{
            //    jumping = true;
            //    ice.gameObject.SetActive(false);
            //    PlayerMove.instance.jumpPower = jumpPowerUp;
            //}
        }

    }
}
