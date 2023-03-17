using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class Detective : NPCBase,IItem
{
    //探偵の状態
    public enum DetectiveState
    {
        SEARCH,                  //自販機の下を探す
        MOVE,                   //移動
        RAIN_STAND,             //雨やどり
        RAIN_MOVE,              //降雨時の移動
        INSUFFICIENTMOISTURE,   //水分不足
        GRATITUDE,              //感謝
    }
    [Header("現在の状態")]public DetectiveState State;

    [Header("コイン")]
    [SerializeField, Tooltip("関連するコイン")] private Coin _coin;
    [SerializeField,Tooltip("フラグデータ")] private ItemData _coinFlag;

    [Header("雨"), SerializeField,Tooltip("フラグデータ")] private FlagData _rain;

    [Header("水分不足")]
    [SerializeField, Tooltip("フラグデータ")] private ItemData _iceFlag;
    [SerializeField, Tooltip("フラグデータ")] private ItemData _drinkFlag;

    [Header("感謝")]
    [SerializeField, Tooltip("上昇したプレイヤーのジャンプ力")] private float _playerJumpPower;

    [Header("移動")]
    [SerializeField, Tooltip("移動速度")] private float _speed = 0.1f;
    //最初の地点
    private Vector3 _startPoint;
    [SerializeField, Tooltip("目的地")] private GameObject _toObject;


    //移動に必要な情報
    private Vector3 _nowPos;        //現在の位置
    private Vector3 _toPos;         //目的地の位置
    private Vector3 _coinPos;       //コインの位置
    [HideInInspector] public bool IsSetPos = false;
    [HideInInspector] public bool moved = false;
    [HideInInspector]public float _currentTime;

    public override int WordTerm()
    {
        return (int)State;
    }

    public override void Start()
    {
        base.Start();
        _startPoint = transform.position;
        _coinPos = _coin.gameObject.transform.position;
    }

    private void Update()
    {
        if (State == DetectiveState.GRATITUDE)
        {
            ChangeWord();
            return;
        }

      

        //動き終わっていない時
        if (!moved)
        {
            State = _rain.IsOn ? DetectiveState.RAIN_MOVE : DetectiveState.MOVE;
            ChangeWord();
            Movement();
            Space = transform.position;
        }

        

        //if (transform.position == _startPoint) _coin.gameObject.GetComponent<BoxCollider2D>().enabled=false;
    }

    //移動
    void Movement()
    {
        //Debug.LogFormat("IsSetPos:{0},NAME:{1}", IsSetPos,INPCData.Data.Name);


        //位置情報の更新
        if (!IsSetPos)
        {
            _currentTime = 0;
            _nowPos = transform.position;
            _toPos = _rain.IsOn ? _toObject.transform.position : _startPoint;
            State = _rain.IsOn ? DetectiveState.RAIN_MOVE : DetectiveState.MOVE;
            IsSetPos = true;
            Animator.SetBool("isMoving", true);
            SetNPCData("move");
            ChangeWord();
        }

        //位置情報を使い動かせる
        if (_nowPos != _toPos)
        {
            _currentTime += Time.deltaTime * _speed;
            transform.position = Vector3.MoveTowards(_nowPos, _toPos, _currentTime);
            //Debug.LogFormat("nowPos:{0},topos:{1}", transform.position, _toPos);
            if (transform.position.x==_toPos.x)
            {
                IsSetPos = false;
                moved = true;
                Animator.SetBool("isMoving", false);
                State = _rain.IsOn ? DetectiveState.RAIN_STAND : DetectiveState.SEARCH;

                //水分不足
                if (_coin.isGet&&State==DetectiveState.SEARCH)
                {
                    State = DetectiveState.INSUFFICIENTMOISTURE;
                    SetNPCData("insufficientMoisture");
                    ChangeWord();
                    return;
                }

                var NPCData = _rain.IsOn ? "move" : "basic";
                SetNPCData(NPCData);
                ChangeWord();


            }
            //Debug.Log("FIN");
        }

        //コインを元の場所に固定する
        _coin.gameObject.transform.position = _coinPos;
    }

    public void SetMovement(bool rain=false)
    {
        //if (rain) State = DetectiveState.RAIN_MOVE;
        IsSetPos = false;
        moved = false;
        Animator.SetBool("isRaining", rain);
    }


    #region NPCBase
    public override void AppearanceWorld()
    {
        base.AppearanceWorld();
        SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Angry);
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

        switch (INPCData.Name)
        {
            case "insufficientMoisture":
                break;
            case "gratitude":
                PlayerMove.Instance.jumpPower = _playerJumpPower;
                break;
        }
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();

        //_coin.gameObject.SetActive(false);
        SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Normal);

        switch (INPCData.Name)
        {
            case "gratitude":
                PlayerMove.Instance.jumpPower = PlayerMove.Instance.basicJumpPower;
                break;
        }
    }
    #endregion

    #region IItem
    public void ItemAction()
    {
        if (State == DetectiveState.INSUFFICIENTMOISTURE && _drinkFlag.IsOn)
        {
            _drinkFlag.SetItemStatus(false);
            SetNPCData("gratitude");
            State = DetectiveState.GRATITUDE;

            ChangeWorld();
        }
    }
    #endregion
}
