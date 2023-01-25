using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    [SerializeField] float jumpPowerDown;

    // 感情世界の取得
    [SerializeField] GameObject before_world;
    [SerializeField] GameObject after_world;

    // プレイヤーの元々の移動速度
    float playerBasicMoveSpeed;

    // 変更後の移動速度
    [SerializeField] float playerMoveSpeedDown;

    // 達成項目のフラグの取得
    [SerializeField] FlagData ChallengeFlag;

    // ゴミを捨てたかどうか
    public bool isAllPickUp = false;

    static bool challengeflag = false;

    int trashCount = 0;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        money.SetActive(false);
        isAllPickUp = false;
        challengeflag = false;
        AuntChangeWord(0);
        //playerBasicMoveSpeed = PlayerMove.instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllPickUp && !money.GetComponent<Money>().isGet) money.SetActive(true);
        if (trashCount >= 3) Words.text = "全部拾ってくれてありがとう";
        Words.fontSize = 2;
    }

    public int TrashCount()
    {
        this.trashCount++;
        return trashCount;
    }

    public void AuntChangeWord(int remaining_num)
    {
        Words.text = "あと" + (3-remaining_num).ToString() + "個拾って";
    }

    public override int WordTerm()
    {
        return (int)State;
    }

    public override void AppearanceWorld()
    {
        base.AppearanceWorld();

        if (INPCData.Name == "happy") PlayerMove.Instance.jumpPower = jumpPowerUped;

        switch (INPCData.Name)
        {
            case "basic":
                PlayerMove.Instance.jumpPower = jumpPowerDown;
                before_world.SetActive(true);
                after_world.SetActive(false);
                //PlayerMove.instance.speed = playerMoveSpeedDown;
                break;
            case "happy":
                PlayerMove.Instance.jumpPower = jumpPowerUped;
                before_world.SetActive(false);
                after_world.SetActive(true);
                break;
        }

        //if (INPCData.Name == "happy") PlayerMove.instance.jumpPower = jumpPowerUped;
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();

        PlayerMove.Instance.jumpPower = PlayerMove.Instance.basicJumpPower;

        //PlayerMove.instance.jumpPower = PlayerMove.instance.basicJumpPower;
        //PlayerMove.instance.speed = playerBasicMoveSpeed;
    }

    public void ItemAction()
    {
        if (trashCount >= 3)
        {
            SetNPCData("happy");
            ChallengeFlag.SetFlagStatus();
        }
        //Debug.Log(trashCount);
    }
}
