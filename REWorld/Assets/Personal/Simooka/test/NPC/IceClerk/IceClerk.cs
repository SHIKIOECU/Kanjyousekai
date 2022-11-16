using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class IceClerk : NPCBase,IItem
{
    //アイス
    [SerializeField]
    private Ice ice;
    //アイテムフラグ（アイス）
    [SerializeField]
    private FlagData iceFlag;

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

    public override void AppearanceWorld()
    {
        base.AppearanceWorld();

        switch (INPCData.Data.Name)
        {
            //アイスが売れていない場合（基本）
            case "basic":
                //アイスを投げる
                ice.gameObject.SetActive(true);
                ice.Rb2D.velocity = new Vector2(_slowSpeed, 0);
                animator.SetBool("throwTrigger", true);
                //Todo:アイスを投げるSEを追加
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Ice_Throw);
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Ice_Wall);
                SoundManagerA.Instance.ChangeBGM(true);
                break;
            //喜んでいる場合
            case "happy":
                //ジャンプする（プレイヤーのジャンプ力も上げる）
                jumping = true;
                ice.gameObject.SetActive(false);
                PlayerMove.instance.jumpPower = jumpPowerUp;
                break;

        }
    }

    public override void DisappearanceWorld()
    {
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
            iceFlag.SetFlagStatus();

            INPCData.SetFlag("happy");

            ChangeWorld();
        }

    }
}
    
