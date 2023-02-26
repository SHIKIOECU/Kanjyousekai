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
    public IceClerkState State;

    //アイス
    [SerializeField]
    private Ice _ice;

    // アイスのオブジェクト
    [SerializeField] private GameObject _iceObj;

    // BigIceAnimeの取得
    [SerializeField] bigIceAnime _iceScr;

    //アイテムフラグ（アイス）
    [SerializeField]
    private ItemData _iceFlag;

    //投げる速度
    [SerializeField]
    private float _slowSpeed;

    //アイテムフラグ（コイン）
    [SerializeField]
    private ItemData coin;

    //ジャンプできるようになったかどうか
    public bool jumping = false;

    //上昇したジャンプ力
    [SerializeField]
    private float jumpPowerUp;

    // アイスの初期位置
    Vector3 basicIcePosition = new Vector3(2.2f, -2.5f, 0.1f);

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
                PlayerMove.Instance.jumpPower = jumpPowerUp;
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
        _iceObj.transform.position = basicIcePosition;
        _iceScr.fallSpeed = 0.0f;
        _iceScr.isMelt = false;
        _iceScr.countDown = _iceScr.timeToMelt;

        base.DisappearanceWorld();

        PlayerMove.Instance.jumpPower = PlayerMove.Instance.basicJumpPower;
    }

    public void ItemAction()
    {
        //Coinを参照してフラグを切り替える
        if (coin.IsOn&&INPCData.Name!="happy")
        {
            coin.SetItemStatus(false);
            _iceFlag.SetItemStatus();
            State = IceClerkState.HAPPY;

            SetNPCData("happy");

            ChangeWorld();
        }

    }
}
    
