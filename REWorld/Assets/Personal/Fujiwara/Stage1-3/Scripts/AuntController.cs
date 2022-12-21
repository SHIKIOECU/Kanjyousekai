using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class AuntController : NPCBase, IItem
{
    public enum AuntState
    {
        SADGE, HAPPY
    }
    public AuntState State;

    // 100円の取得
    [SerializeField] GameObject money;

    // 変更後のジャンプ力
    [SerializeField] float jumpPowerUped;

    // ゴミを捨てたかどうか
    public bool isAllPickUp = false;

    int trashCount = 0;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        money.SetActive(false);
        isAllPickUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllPickUp && !money.GetComponent<Money>().isGet) money.SetActive(true);
    }

    public int TrashCount()
    {
        this.trashCount++;
        return trashCount;
    }

    public override int WordTerm()
    {
        return (int)State;
    }

    public override void AppearanceWorld()
    {
        base.AppearanceWorld();

        if (INPCData.Name == "happy") PlayerMove.instance.jumpPower = jumpPowerUped;
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();

        PlayerMove.instance.jumpPower = PlayerMove.instance.basicJumpPower;
    }

    public void ItemAction()
    {
        if (trashCount >= 3)
        {
            isAllPickUp = true;
            SetNPCData("happy");
        }
        Debug.Log(trashCount);
    }
}
