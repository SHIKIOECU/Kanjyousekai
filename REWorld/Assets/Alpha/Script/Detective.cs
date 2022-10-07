using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detective : MonoBehaviour
{
    //NPCData
    [SerializeField]
    private NPCData NData;

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

    [SerializeField]
    private Coin _coinItem;

    [SerializeField]
    private FlagData _girl;

    [SerializeField]
    private GameObject pointA;
    [SerializeField]
    private GameObject pointB;

    [SerializeField]
    private float Speed;

    private Vector3 nowPos;
    private Vector3 toPos;
    private Vector3 coinPos;

    public bool isSetPos = false;
    public bool moved = false;
    public float _currentTime;

    private void Start()
    {
        coinPos = _coinItem.gameObject.transform.position;
        EmotionalWorld.SetActive(false);
        FlagReset();
        FlagDatas[0].SetFlagStatus();
    }

    private void Update()
    {
        if (!moved) Movement();
        if (FlagDatas[0].IsOn&&_currentTime!=0&&!_coinItem.isGet)
        {
            _coinItem.gameObject.SetActive(true);
        }
        else
        {
            _coinItem.gameObject.SetActive(false);
        }
    }

    //フラグを全てfalseにする
    void FlagReset()
    {
        for (int i = 0; i < FlagDatas.Count; i++)
        {
            FlagDatas[i].InitFlag();
        }
    }

   

    void Movement()
    {
        if (FlagDatas[1].IsOn && !isSetPos)
        {
            nowPos = transform.position;
            toPos = pointA.transform.position;
            isSetPos = true;
        }

        if (!FlagDatas[1].IsOn && !isSetPos)
        {
            _currentTime = 0;
            nowPos = transform.position;
            toPos = pointB.transform.position;
            isSetPos = true;
        }

        if (nowPos != toPos)
        {
            _currentTime += Time.deltaTime * Speed;
            transform.position = Vector3.Lerp(nowPos, toPos, _currentTime);
            if (_currentTime >= 1)
            {
                isSetPos = false;
                _currentTime = 0;
            }
        }

        _coinItem.gameObject.transform.position = coinPos;
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
        if (FlagDatas[1])
        {
            _coinItem.gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            _coinItem.gameObject.GetComponent<Collider2D>().enabled = false;
        }

    }

    public void SetActiveWorld()
    {
        EmotionalWorld.SetActive(true);
        if (!_coinItem.isGet) _coinItem.gameObject.SetActive(true);
    }
}
