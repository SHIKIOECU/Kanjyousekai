using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Girl : MonoBehaviour, INPC,IItem
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

    private void Start()
    {
        EmotionalWorld.SetActive(false);
        FlagReset();
        FlagDatas[0].SetFlagStatus();
    }

    private void Update()
    {
        if (!EmotionalWorld.active)
        {
            _detective.SetFlagStatus(false);
            detective.isSetPos = false;
        }
    }

    //フラグを全てfalseにする
    void FlagReset()
    {
        for(int i = 0; i < _flag.Count; i++)
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

        if (FlagDatas[0].IsOn)
        {
            _detective.SetFlagStatus();
            detective.isSetPos = false;
        }
       

        detective.moved = false;
    }

    //感情世界の画像を変更
    public void ChangeWorld()
    {
        for (int i = 0; i < _flag.Count; i++)
        {
            if (FlagDatas[i].IsOn)
            {
                EmotionalWorld.GetComponent<SpriteRenderer>().sprite = EmotionalWorldSprite[i];
                if(_gimmick!=null) _gimmick.SetActive(true);
                break;
            }
        }
    }

    //ItemListを参照してフラグを切り替える
    public void ItemAction()
    {
        if (_ice.IsOn)
        {
            _ice.InitFlag();
            FlagReset();
            FlagDatas[1].SetFlagStatus();

            _gimmick = _gimmickList[0];
            ChangeWorld();
        }

    }

    
}
