using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class CactusController : NPCBase
{
    [SerializeField] HawkerController hawker;
    [SerializeField] CamelController camel;

    [SerializeField] Animator cactus_anim;

    public bool isCactusKansoku;

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
        //Debug.Log("cactusが観測されました");
        base.AppearanceWorld();

        cactus_anim.SetBool("isDancing", true);

        hawker.nowPos = hawker.transform.position;

        hawker.moved = true;
        hawker.onCactus = true;
        camel.isFollowing = true;
        isCactusKansoku = true;
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();

        cactus_anim.SetBool("isDancing", false);

        //hawker.onCactus = false;
        camel.isFollowing = false;
        isCactusKansoku = false;
        hawker.moved = false;
        //Debug.Log("cactusの感情世界を消しました");
    }

    
}
