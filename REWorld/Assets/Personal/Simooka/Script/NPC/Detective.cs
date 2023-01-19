using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class Detective : NPCBase
{
    public enum DetectiveState
    {
        SERCH, MOVE,
        RAIN_STAND, RAIN_MOVE,
    }
    public DetectiveState State;

    //コイン
    [SerializeField]
    private Coin _coin;

    //アイテム（コイン）フラグ
    [SerializeField]
    private FlagData _coinFlag;

    //雨フラグ
    [SerializeField]
    private FlagData _rain;

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
    public bool IsSetPos = false;
    public bool moved = false;
    public float _currentTime;

    public override void Start()
    {
        base.Start();
        _startPoint = transform.position;
        _coinPos = _coin.gameObject.transform.position;
    }

    private void Update()
    {
        //動き終わっていない時
        if (!moved)
        {
            
            if (_rain.IsOn) State = DetectiveState.RAIN_MOVE;
            else State = DetectiveState.MOVE;
            Movement();
        }

        if (transform.position == _startPoint) _coin.gameObject.GetComponent<BoxCollider2D>().enabled=false;
    }

    //移動
    void Movement()
    {
        //Debug.LogFormat("IsSetPos:{0},NAME:{1}", IsSetPos,INPCData.Data.Name);


        //位置情報の更新
        if (State==DetectiveState.RAIN_MOVE && !IsSetPos)
        {
            _currentTime = 0;
            _nowPos = transform.position;
            _toPos = _toObject.transform.position;
            IsSetPos = true;
            Animator.SetBool("isMoving", true);
            //Debug.Log("MOVE");
        }
        if (State==DetectiveState.MOVE && !IsSetPos)
        {
            _currentTime = 0;
            _nowPos = transform.position;
            _toPos = _startPoint;
            IsSetPos = true;
            Animator.SetBool("isMoving", true);
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
                IsSetPos = false;
                moved = true;
                Animator.SetBool("isMoving", false);
            }
            //Debug.Log("FIN");
        }

        //コインを元の場所に固定する
        _coin.gameObject.transform.position = _coinPos;
    }



    public override void AppearanceWorld()
    {
        base.AppearanceWorld();

        //コインを持っていない時
        if (!_coin.isGet)
        {
            _coin.gameObject.SetActive(true);
            _coin.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            _coin.gameObject.SetActive(false);
        }
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();

        _coin.gameObject.SetActive(false);
    }
}
