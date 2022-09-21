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

    private bool isSetPos = false;
    [SerializeField]
    private bool moved = false;
    private float _currentTime;

    private void Start()
    {
        coinPos = _coinItem.gameObject.transform.position;
    }

    private void Update()
    {
        if (!moved) Movement();
    }

    //フラグを全てfalseにする
    void FlagReset()
    {
        for (int i = 0; i < _flag.Count; i++)
        {
            _flag[i].InitFlag();
        }
    }

    void Movement()
    {
        if (_flag[1].IsOn && !isSetPos)
        {
            nowPos = transform.position;
            toPos = pointA.transform.position;
            isSetPos = true;
        }

        if (_flag[0].IsOn && !isSetPos)
        {
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
                moved = true;
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

        for (int i = 0; i < _flag.Count; i++)
        {
            if (FlagDatas[i].IsOn)
            {
                EmotionalWorld.GetComponent<SpriteRenderer>().sprite = EmotionalWorldSprite[i];
                moved = false;
                Debug.Log("ChangeWorld");
                break;
            }
        }
    }

    public void SetActiveWorld()
    {
        EmotionalWorld.SetActive(true);
        if (!_coinItem.isGet) _coinItem.gameObject.SetActive(true);
    }
}
