using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class Detective : NPCBase
{
    //コイン
    [SerializeField]
    private Coin coin;

    //アイテム（コイン）フラグ
    [SerializeField]
    private FlagData coinFlag;

    //雨フラグ
    [SerializeField]
    private FlagData rain;

    //最初の地点
    private Vector3 _startPoint;
    //移動地点
    [SerializeField]
    private GameObject _toObject;

    //NPCの移動速度
    [SerializeField]
    private float _speed = 0.1f;

    //移動に必要な情報
    //位置、情報、位置情報のセットしたかどうか、動き終わったかどうか、移動時間
    private Vector3 _nowPos;
    private Vector3 _toPos;
    private Vector3 _coinPos;
    public bool isSetPos = false;
    public bool moved = false;
    public float _currentTime;

    public override void Start()
    {
        base.Start();
        _startPoint = transform.position;
        _coinPos = coin.gameObject.transform.position;
    }

    private void Update()
    {
        //動き終わっていない時
        if (!moved) Movement();

        if (transform.position == _startPoint) coin.gameObject.SetActive(false);
    }

    //移動
    void Movement()
    {
        //Debug.LogFormat("isSetPos:{0},NAME:{1}", isSetPos,INPCData.Data.Name);


        //位置情報の更新
        if (INPCData.Data.Name == "move" && !isSetPos)
        {
            _currentTime = 0;
            _nowPos = transform.position;
            _toPos = _toObject.transform.position;
            isSetPos = true;
            animator.SetBool("isMoving", true);
            //Debug.Log("MOVE");
        }
        if (INPCData.Data.Name != "move" && !isSetPos)
        {
            _currentTime = 0;
            _nowPos = transform.position;
            _toPos = _startPoint;
            isSetPos = true;
            animator.SetBool("isMoving", true);
            //Debug.Log("STOP");
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
                animator.SetBool("isMoving", false);
            }
            //Debug.Log("FIN");
        }

        //コインを元の場所に固定する
        coin.gameObject.transform.position = _coinPos;
    }



    public override void AppearanceWorld()
    {
        base.AppearanceWorld();

        //コインを持っていない時
        if (!coin.isGet)
        {
            coin.gameObject.SetActive(true);
        }
        else
        {
            coin.gameObject.SetActive(false);
        }
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();

        coin.gameObject.SetActive(false);
    }
}
