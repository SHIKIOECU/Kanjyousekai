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
