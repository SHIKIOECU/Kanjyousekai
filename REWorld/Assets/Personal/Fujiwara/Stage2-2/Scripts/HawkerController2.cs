using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class HawkerController2 : NPCBase
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
        base.AppearanceWorld();
    }

    public override void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();
    }
}
