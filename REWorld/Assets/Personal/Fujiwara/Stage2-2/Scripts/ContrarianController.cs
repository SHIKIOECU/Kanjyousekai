using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class ContrarianController : NPCBase
{
    // NPCの取得
    [SerializeField] HawkerController2 hawker;
    [SerializeField] GorillaController gorilla;

    void Start()
    {
        base.DisappearanceWorld();
        gorilla.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    void Update()
    {

    }

    public override void AppearanceWorld()
    {
        // 感情世界の表示
        base.AppearanceWorld();

        // ゴリラのisTriggerをtrueにする
        //gorillaCollider.isTrigger = true;
        gorilla.GetComponent<BoxCollider2D>().isTrigger = true;

        // NPCのステータスを変更する
        hawker.INPCData.SetFlag("cold");
        gorilla.INPCData.SetFlag("sleep");
    }

    public override void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void DisappearanceWorld()
    {
        // 感情世界の削除
        base.DisappearanceWorld();

        // ゴリラのisTriggerをfalseにする
        //gorillaCollider.isTrigger = false;
        gorilla.GetComponent<BoxCollider2D>().isTrigger = false;

        // NPCのステータスを変更する
        hawker.INPCData.SetFlag("basic");
        gorilla.INPCData.SetFlag("basic");
    }
}
