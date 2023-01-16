using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class Pyragorilla : NPCBase, IItem
{
    [SerializeField] FlagData necklace;
    [SerializeField] FlagData banana;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void AppearanceWorld()
    {
        base.AppearanceWorld();
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();
    }

    public void ItemAction()
    {
        if (banana.IsOn)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            SetNPCData("happy");
            ChangeWord();
        }
        else if (necklace.IsOn) {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            SetNPCData("complain");
            ChangeWord();
        }
    }
}
