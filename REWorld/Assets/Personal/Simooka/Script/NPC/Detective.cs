using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class Detective : NPCBase,IItem
{
    public enum DetectiveState
    {
        SERCH, MOVE,
        RAIN_STAND, RAIN_MOVE,
        INSUFFICIENTMOISTURE,
        GRATITUDE,
    }
    public DetectiveState State;

    //コイン
    [Header("コイン"),SerializeField]
    private Coin _coin;

    //アイテム（コイン）フラグ
    [SerializeField]
    private ItemData _coinFlag;

    //雨フラグ
    [Header("雨"),SerializeField]
    private FlagData _rain;

    [Header("水分不足")]
    [SerializeField] private ItemData _iceFlag;
    [SerializeField] private ItemData _drinkFlag;

    [Header("感謝")]
    [SerializeField] private float _playerJumpPower;

    [Header("移動関連")]
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
        if (State == DetectiveState.GRATITUDE) return;

        //水分不足
        if ((_coinFlag.IsOn && _iceFlag.IsOn)||_drinkFlag.IsOn)
        {
            State = DetectiveState.INSUFFICIENTMOISTURE;
            return;
        }

        //動き終わっていない時
        if (!moved)
        {

            if (_rain.IsOn)
            {
                State = DetectiveState.RAIN_MOVE;
                ChangeWord();
            }
            else
            {
                State = DetectiveState.MOVE;
                ChangeWord();
            }
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
            transform.position = Vector3.MoveTowards(_nowPos, _toPos, _currentTime);
            //Debug.LogFormat("nowPos:{0},topos:{1}", transform.position, _toPos);
            if (transform.position.x==_toPos.x)
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
