using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class Girl : NPCBase,IItem
{
    //アイテム（アイス）フラグ
    [SerializeField]
    private ItemData iceFlag;

    //探偵
    [SerializeField]
    private Detective detective;

    //虹
    [SerializeField]
    private GameObject _rainbow;

    [SerializeField]
    private FlagData _rain;

    public bool _getIce;


    public override void AppearanceWorld()
    {
        base.AppearanceWorld();

        switch (INPCData.Name)
        {
            //泣いている場合（基本）
            case "basic":
                _rain.SetFlagStatus();
                //Todo:雨のBGMを追加
                SoundManagerA.Instance.PlayBGM(5);
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Sad);
                playerWalk_Sound.InstanceWalk.WalkSE_Change(playerWalk_Sound.WalkSE_List.Rain);
                //探偵を雨宿りさせる
                detective.SetMovement(true);
                break;
            //喜んでいる場合
            case "happy":
                _rain.SetFlagStatus(false);
                detective.SetMovement();
                //虹を出現させる
                _rainbow.SetActive(true);
                //Todo:虹を出現させるSEを追加
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Happy);
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Rainbow);
                SoundManagerA.Instance.stopBGM(5);
                break;

        }
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();

        switch (INPCData.Name)
        {
            //泣いている場合（基本）
            case "basic":
                _rain.SetFlagStatus(false);
                detective.SetNPCData("basic");
                detective.Animator.SetBool("isRaining", false);
                detective.IsSetPos = false;
                detective.moved = false;
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Normal);
                playerWalk_Sound.InstanceWalk.WalkSE_Change(playerWalk_Sound.WalkSE_List.HardFloor);
                SoundManagerA.Instance.stopBGM(5);
                break;
            //喜んでいる場合
            case "happy":
                _rainbow.SetActive(false);
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Normal);
                break;

        }
    }

    public void ItemAction()
    {
        //iceFlagを参照してフラグを切り替える
        if (iceFlag.IsOn)
        {
            _getIce = true;
            iceFlag.SetItemStatus(false);
            SetNPCData("happy");

            ChangeWorld();
        }

    }


}
