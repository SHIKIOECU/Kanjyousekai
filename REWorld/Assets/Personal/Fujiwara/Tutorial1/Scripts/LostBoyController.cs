using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class LostBoyController : NPCBase
{
    // ボートの取得
    [SerializeField] GameObject boat;

    // ボートの移動先のポジション
    private Vector3 moveToPos = new Vector3(29, 0, 0);
    private Vector3 defaultPos;

    void Start()
    {
        // 感情世界の削除
        base.DisappearanceWorld();

        // ボートの現在の位置を取得
        defaultPos = boat.transform.position;
    }

    void Update()
    {

    }

    public override void AppearanceWorld()
    {
        // 感情世界の表示
        base.AppearanceWorld();

        // boatの位置を移動させて水を出現させる
        boat.transform.position = moveToPos;

        // LostGirlの状態を変化させる
        INPCData.SetFlag("cry");
    }

    public override void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void DisappearanceWorld()
    {
        // 感情世界の削除
        base.DisappearanceWorld();

        // boatの位置を元の位置に戻す
        boat.transform.position = defaultPos;

        // LostGirlの状態を変化させる
        INPCData.SetFlag("basic");
    }
}
