using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class AuntController : NPCBase
{
    // 10円の取得
    [SerializeField] GameObject money;

    // 変更後のジャンプ力
    [SerializeField] float jumpPowerUped;

    // ゴミを捨てたかどうか
    public bool isAllPickUp = false;

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
}