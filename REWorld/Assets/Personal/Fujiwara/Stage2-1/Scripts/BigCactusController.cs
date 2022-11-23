using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class BigCactusController : NPCBase
{
    [SerializeField] HawkerController hawker;
    [SerializeField] CamelController camel;
    [SerializeField] DesertGirlController desertGirl;

    [SerializeField] Animator big_cactus_anim;

    public bool isBigCactusKansoku;

    // Start is called before the first frame update
    void Start()
    {
        base.DisappearanceWorld();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void AppearanceWorld()
    {
        // 感情世界の表示
        base.AppearanceWorld();

        // 自分を踊り状態にする
        big_cactus_anim.SetBool("isDancing", true);

        // 少女を踊り状態にする
        desertGirl.desert_girl_anim.SetBool("isHappy", true);
        desertGirl.INPCData.SetFlag("happy");

        hawker.nowPos = hawker.transform.position;
        
        hawker.moved = true;
        hawker.onBigCactus = true;
        camel.isFollowing = true;
        desertGirl.isMoving = true;

        isBigCactusKansoku = true;
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();

        // 自分を通常の状態に戻す
        big_cactus_anim.SetBool("isDancing", false);

        // 少女を怯え状態に戻す
        desertGirl.INPCData.SetFlag("frightening");
        desertGirl.desert_girl_anim.SetBool("isHappy", false);

        //hawker.onBigCactus = false;
        camel.isFollowing = false;
        isBigCactusKansoku = false;
        hawker.moved = false;
        desertGirl.isMoving = false;
    }
}
