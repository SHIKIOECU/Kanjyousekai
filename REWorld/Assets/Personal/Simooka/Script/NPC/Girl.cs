using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class Girl : NPCBase,IItem
{
    //アイテム（アイス）フラグ
    [SerializeField]
    private FlagData iceFlag;

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
                SoundManagerA.Instance.PlayBGM(2);
                SoundManagerA.Instance.ChangeBGM(true);
                //探偵を雨宿りさせる
                detective.SetNPCData("move");
                detective.IsSetPos = false;
                detective.moved = false;
                detective.Animator.SetBool("isRaining", true);
                break;
            //喜んでいる場合
            case "happy":
                //虹を出現させる
                _rainbow.SetActive(true);
                //Todo:虹を出現させるSEを追加
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Rainbow);
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
                SoundManagerA.Instance.ChangeBGM(false);
                SoundManagerA.Instance.stopBGM(2);
                break;
            //喜んでいる場合
            case "happy":
                _rainbow.SetActive(false);
                break;

        }
    }

    public void ItemAction()
    {
        //iceFlagを参照してフラグを切り替える
        if (iceFlag.IsOn)
        {
            _getIce = true;
            iceFlag.SetFlagStatus(false);
            SetNPCData("happy");

            ChangeWorld();
        }

    }


}
