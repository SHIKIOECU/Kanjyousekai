using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceClerk : MonoBehaviour,INPC,IItem
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

    [SerializeField]
    private Ice ice;

    //アイテムフラグ
    [SerializeField]
    private FlagData _ice;

    [SerializeField]
    private float slowSpeed;

    //アイテムフラグ
    [SerializeField]
    private FlagData _coin;

    [SerializeField]
    private GameObject _gimmick;

    [SerializeField]
    private List<GameObject> _gimmickList;

    //アニメーター
    private Animator animator;

    //ジャンプできるようになったかどうか
    public bool jumping = false;

    [SerializeField]
    private float jumpPowerUp;

    private void Start()
    {
        EmotionalWorld.SetActive(false);
        FlagReset();
        FlagDatas[0].SetFlagStatus();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!EmotionalWorld.active)
        {
            PlayerMove.instance.jumpPower = PlayerMove.instance.basicJumpPower;
        }
    }

    //フラグを全てfalseにする
    void FlagReset()
    {
        for (int i = 0; i < _flag.Count; i++)
        {
            _flag[i].InitFlag();
        }
    }

    //インターフェースの定義
    public GameObject EmotionalWorld => _emotionalWorld;

    public List<Sprite> EmotionalWorldSprite => _emotionalWorldSprites;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => _words;

    public List<string> WordsText => _wordsText;

    public List<FlagData> FlagDatas => _flag;

    public void SetActiveWorld()
    {
        EmotionalWorld.SetActive(true);

        if (_flag[0].IsOn)
        {
            ice.gameObject.SetActive(true);
            ice.Rb2D.velocity = new Vector2(slowSpeed, 0);
            //アニメーターの設定
            animator.SetBool("throwTrigger", true);
        }

        if (_flag[1].IsOn)
        {
            jumping = true;
            Destroy(ice.gameObject);
            PlayerMove.instance.jumpPower = jumpPowerUp;
        }
    }

    //感情世界の画像を変更
    public void ChangeWorld()
    {
        for (int i = 0; i < _flag.Count; i++)
        {
            if (FlagDatas[i].IsOn)
            {
                EmotionalWorld.GetComponent<SpriteRenderer>().sprite = EmotionalWorldSprite[i];
                break;
            }
        }
    }

    //ItemListを参照してフラグを切り替える
    public void ItemAction()
    {
        if (_coin.IsOn)
        {
            _coin.InitFlag();
            _ice.SetFlagStatus();

            FlagReset();
            FlagDatas[1].SetFlagStatus();

            ChangeWorld();

            //仮
            if (_flag[1].IsOn)
            {
                jumping = true;
                Destroy(ice.gameObject);
                PlayerMove.instance.jumpPower = jumpPowerUp;
            }
        }

    }
}
