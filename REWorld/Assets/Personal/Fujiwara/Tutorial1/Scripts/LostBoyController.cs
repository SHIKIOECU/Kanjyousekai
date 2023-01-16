using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class LostBoyController : NPCBase
{
    // ボートの取得
    [SerializeField] GameObject boat;

    // 父親の取得
    [SerializeField] GameObject father;

    // 虹の取得
    [SerializeField] GameObject rainbow;

    // ボートの移動先のポジション
    private Vector3 moveToPos = new Vector3(0, 4.5f, 0);
    private Vector3 defaultPos;

    // 少年を観測したかどうか
    public bool isFather;

    public bool isReunion;

    public override void Start()
    {
        base.Start();

        // 感情世界の削除
        //base.DisappearanceWorld();

        AllInit();

        // ボートの現在の位置を取得
        defaultPos = boat.transform.position;
    }

    void Update()
    {

    }

    private void AllInit()
    {
        isFather = false;
        isReunion = false;
        rainbow.SetActive(false);
    }

    public override void AppearanceWorld()
    {
        // 感情世界の表示
        base.AppearanceWorld();

        switch (isReunion)
        {
            case true:
                rainbow.SetActive(true);
                break;
            case false:
                // boatの位置を移動させて水を出現させる
                boat.transform.position = moveToPos;
                break;
        }

        // LostGirlの状態を変化させる
        SetNPCData("cry");

        if (father.GetComponent<FatherController>().isFather) isFather = true;
    }

    public override void ChangeWorld()
    {
        //throw new System.NotImplementedException();
    }

    public override void DisappearanceWorld()
    {
        // 感情世界の削除
        base.DisappearanceWorld();

        switch (isReunion)
        {
            case true:
                rainbow.SetActive(false);
                break;
            case false:
                // boatの位置を元の位置に戻す
                boat.transform.position = defaultPos;
                break;
        }

        // LostGirlの状態を変化させる
        SetNPCData("basic");
    }
}
