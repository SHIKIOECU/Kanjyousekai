using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class IceClerk : NPCBase,IItem
{
    public enum IceClerkState
    {
        STAND,HAPPY,
    }
    [Header("現在の状態")] public IceClerkState State;

    [Header("アイス")]
    [SerializeField] private Ice _ice;

    [SerializeField,Tooltip("アイスのオブジェクト")] private GameObject _iceObj;

    //BigIceAnimeの取得
    [SerializeField, Tooltip("アイスのアニメーション")] private bigIceAnime _iceScr;

    [SerializeField, Tooltip("フラグ")] private ItemData _iceFlag;

    [Tooltip("アイスの初期位置")] private Vector3 _basicIcePosition = new Vector3(2.2f, -2.5f, 0.1f);

    [Header("コイン")]
    [SerializeField, Tooltip("フラグ")] private ItemData _coin;

    [Header("挙動")]
    [SerializeField, Tooltip("アイスを投げる速度")] private float _slowSpeed;

    //ジャンプできるようになったかどうか
    public bool jumping = false;

    [SerializeField,Tooltip("喜んでいる時のジャンプ力")] private float _jumpPowerUp;

    

    public override int WordTerm()
    {
        return (int)State;
    }

    public override void AppearanceWorld()
    {
        base.AppearanceWorld();

        switch (INPCData.Name)
        {
            //アイスが売れていない場合（基本）
            case "basic":
                //アイスを投げる
                _ice.gameObject.SetActive(true);
                _ice.Rb2D.velocity = new Vector2(_slowSpeed, 0);
                Animator.SetBool("throwTrigger", true);
                //アイスを投げるSEを追加
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Ice_Throw);
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Ice_Wall);
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Sad);
                break;
            //喜んでいる場合
            case "happy":
                //ジャンプする（プレイヤーのジャンプ力も上げる）
                Animator.SetBool("jumpTrigger", true);
                jumping = true;
                _ice.gameObject.SetActive(false);
                PlayerMove.Instance.jumpPower = _jumpPowerUp;
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Happy);
                break;

        }
    }

    public override void DisappearanceWorld()
    {
        SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Normal);
        Animator.SetBool("throwTrigger", false);
        Animator.SetBool("jumpTrigger", false);
        //アイスの動作
        _iceObj.transform.position = _basicIcePosition;
        _iceScr.fallSpeed = 0.0f;
        _iceScr.isMelt = false;
        _iceScr.countDown = _iceScr.timeToMelt;

        base.DisappearanceWorld();

        PlayerMove.Instance.jumpPower = PlayerMove.Instance.basicJumpPower;
    }

    public void ItemAction()
    {
        //Coinを参照してフラグを切り替える
        if (_coin.IsOn&&INPCData.Name!="happy")
        {
            _coin.SetItemStatus(false);
            _iceFlag.SetItemStatus();
            State = IceClerkState.HAPPY;

            SetNPCData("happy");

            ChangeWorld();
        }

    }
}
    
