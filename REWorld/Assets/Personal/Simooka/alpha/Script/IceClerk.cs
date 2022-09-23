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

    private void Start()
    {

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
        if (_flag[1].IsOn)
        {
            ice.transform.position = this.transform.position;
            ice.Rb2D.velocity = new Vector2(slowSpeed, 0);
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
        }

    }
}
