using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detective : MonoBehaviour,INPC
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

    //コイン
    [SerializeField]
    private Coin coin;

    //アイテム（コイン）フラグ
    [SerializeField]
    private FlagData coinFlag;

    //雨フラグ
    [SerializeField]
    private FlagData rain;

    //アニメーター
    private Animator _animator;

    //移動地点
    [SerializeField]
    private GameObject _pointA;
    [SerializeField]
    private GameObject _pointB;

    //NPCの移動速度
    [SerializeField]
    private float _speed=0.1f;

    //移動に必要な情報
    //位置、情報、位置情報のセットしたかどうか、動き終わったかどうか、移動時間
    private Vector3 _nowPos;
    private Vector3 _toPos;
    private Vector3 _coinPos;
    public bool isSetPos = false;
    public bool moved = false;
    public float _currentTime;

    private void Start()
    {
        _coinPos = coin.gameObject.transform.position;
        EmotionalWorld.SetActive(false);
        INPCData.InitNPCFlag();
        //_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //動き終わっていない時
        if (!moved) Movement();

        //自販機に戻るときにコインを持っていない時
        if (INPCData.Data.Name!="move"&&_currentTime!=0&&!coin.isGet)
        {
            coin.gameObject.SetActive(true);
        }
        else
        {
            coin.gameObject.SetActive(false);
        }
    }

    //移動
    void Movement()
    {
        //Debug.LogFormat("isSetPos:{0},NAME:{1}", isSetPos,INPCData.Data.Name);


        //位置情報の更新
        if (INPCData.Data.Name=="move" && !isSetPos)
        {
            _currentTime = 0;
            _nowPos = transform.position;
            _toPos = _pointA.transform.position;
            isSetPos = true;
            Debug.Log("MOVE");
        }
        if (INPCData.Data.Name != "move" && !isSetPos)
        {
            _currentTime = 0;
            _nowPos = transform.position;
            _toPos = _pointB.transform.position;
            isSetPos = true;
            Debug.Log("STOP");
        }

        //位置情報を使い動かせる
        if (_nowPos != _toPos)
        {
            _currentTime += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_nowPos, _toPos, _currentTime);
            //Debug.LogFormat("nowPos:{0},topos:{1}", transform.position, _toPos);
            if (_currentTime >= 1)
            {
                isSetPos = false;
                moved = true;
            }
            //Debug.Log("FIN");
        }

        //コインを元の場所に固定する
        coin.gameObject.transform.position = _coinPos;
    }

    //インターフェースを実装
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
    }

    public void ChangeWorld()
    {
        
    }

    public void DisappearanceWorld()
    {
        EmotionalWorld.SetActive(false);
    }
}
