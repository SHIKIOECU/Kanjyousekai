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

<<<<<<< HEAD
    public NPCData INPCData => NData;

    public GameObject EmotionalWorld => _emotionalWorld;

    public Sprite EmotionalWorldSprite => INPCData.Data.EmotionalWorldSprite;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => throw new System.NotImplementedException();

    public List<string> WordsText => throw new System.NotImplementedException();

    public GameObject MaskSprite => throw new System.NotImplementedException();

    public void AppearanceWorld()
=======
    public override void AppearanceWorld()
>>>>>>> feature/NPC/Fujiwara
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
