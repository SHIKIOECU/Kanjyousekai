using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class GorillaController : NPCBase
{
    void Start()
    {
        base.DisappearanceWorld();
    }

    void Update()
    {

    }

    public override void AppearanceWorld()
    {
        // 感情世界の表示
        base.AppearanceWorld();

        // ゴリラのステータスを変更
        INPCData.SetFlag("hungry");
    }

    public override void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void DisappearanceWorld()
    {
        // 感情世界の削除
        base.DisappearanceWorld();

        // ゴリラのステータスを変更
        INPCData.SetFlag("basic");
    }
}
