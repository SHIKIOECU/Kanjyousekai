using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class IceClerk : NPCBase,IItem
{
    //アイス
    [SerializeField]
    private Ice _ice;

    // アイスのオブジェクト
    [SerializeField] private GameObject _iceObj;

    // BigIceAnimeの取得
    [SerializeField] bigIceAnime _iceScr;

    //アイテムフラグ（アイス）
    [SerializeField]
    private FlagData _iceFlag;

    //投げる速度
    [SerializeField]
    private float _slowSpeed;

    //アイテムフラグ（コイン）
    [SerializeField]
    private FlagData coin;

    //ジャンプできるようになったかどうか
    public bool jumping = false;

    //上昇したジャンプ力
    [SerializeField]
    private float jumpPowerUp;

    // アイスの初期位置
    Vector3 basicIcePosition = new Vector3(2.2f, -2.5f, 0.1f);

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
                //Todo:アイスを投げるSEを追加
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Ice_Throw);
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Ice_Wall);
                SoundManagerA.Instance.ChangeBGM(true);
                break;
            //喜んでいる場合
            case "happy":
                //ジャンプする（プレイヤーのジャンプ力も上げる）
                Animator.SetBool("jumpTrigger", true);
                jumping = true;
                _ice.gameObject.SetActive(false);
                PlayerMove.instance.jumpPower = jumpPowerUp;
                break;

        }
    }

    public override void DisappearanceWorld()
    {
        Animator.SetBool("throwTrigger", false);
        Animator.SetBool("jumpTrigger", false);
        //アイスの動作
        _iceObj.transform.position = basicIcePosition;
        _iceScr.fallSpeed = 0.0f;
        _iceScr.isMelt = false;
        _iceScr.countDown = _iceScr.timeToMelt;

        base.DisappearanceWorld();

        PlayerMove.instance.jumpPower = PlayerMove.instance.basicJumpPower;
        SoundManagerA.Instance.ChangeBGM(false);
    }

    public void ItemAction()
    {
        //Coinを参照してフラグを切り替える
        if (coin.IsOn)
        {
            coin.SetFlagStatus(false);
            _iceFlag.SetFlagStatus();

            SetNPCData("happy");

            ChangeWorld();
        }

    }
}
    
