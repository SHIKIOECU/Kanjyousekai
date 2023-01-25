using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class LostBoyController : NPCBase
{
    public enum LostBoyState
    {
        FLUSTERED, CRY, REUNION, HAPPY
    }
    public LostBoyState State;

    // ボートの取得
    [SerializeField] GameObject boat;

    // 父親の取得
    [SerializeField] GameObject father;

    // 虹の取得
    [SerializeField] GameObject rainbow;

    // 水の取得
    [SerializeField] GameObject[] waters;

    // spriteの取得
    //Sprite lostboySprite;
    [SerializeField] Sprite fatherSprite_jump;
    [SerializeField] Sprite[] lostboySprites;

    SpriteRenderer lostboySprite;
    SpriteRenderer fatherSprite;

    // ボートの移動先のポジション
    private Vector3 moveToPos = new Vector3(0, 3.13f, 0);
    private Vector3 defaultPos;

    // 少年を観測したかどうか
    public bool isFather;

    public bool isReunion;

    public override void Start()
    {
        base.Start();

        // 感情世界の削除
        //base.DisappearanceWorld();

        AllInit();

        // ボートの現在の位置を取得
        defaultPos = boat.transform.position;
        foreach (GameObject water in waters) water.SetActive(false);

        lostboySprite = gameObject.GetComponent<SpriteRenderer>();
        lostboySprite.sprite = lostboySprites[0];

        fatherSprite = father.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    public override int WordTerm()
    {
        return (int)State;
    }

    private void AllInit()
    {
        isFather = false;
        isReunion = false;
        rainbow.SetActive(false);
    }

    public override void AppearanceWorld()
    {
        switch (isReunion)
        {
            case true:
                SetNPCData("power");
                lostboySprite.sprite = lostboySprites[4];
                //fatherSprite.sprite = fatherSprite_jump;

                rainbow.SetActive(true);
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Happy);
                SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Rainbow);
                SoundManagerA.Instance.stopBGM(5);
                break;
            case false:
                SetNPCData("lost");
                lostboySprite.sprite = lostboySprites[1];

                // boatの位置を移動させて水を出現させる
                boat.transform.position = moveToPos;
                foreach (GameObject water in waters) water.SetActive(true);
                SoundManagerA.Instance.PlayBGM(5);
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Sad);
                playerWalk_Sound.InstanceWalk.WalkSE_Change(playerWalk_Sound.WalkSE_List.Rain);
                break;
        }

        if (father.GetComponent<FatherController>().isFather) isFather = true;

        // 感情世界の表示
        base.AppearanceWorld();
    }

    public override void ChangeWorld()
    {
        //throw new System.NotImplementedException();
    }

    public override void DisappearanceWorld()
    {
        switch (isReunion)
        {
            case true:
                SetNPCData("reunion");
                lostboySprite.sprite = lostboySprites[3];

                rainbow.SetActive(false);
                boat.transform.position = defaultPos;
                foreach (GameObject water in waters) water.SetActive(false);
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Normal);

                father.SetActive(false);
                break;
            case false:
                SetNPCData("basic");
                lostboySprite.sprite = lostboySprites[0];

                // boatの位置を元の位置に戻す
                boat.transform.position = defaultPos;
                foreach (GameObject water in waters) water.SetActive(false);
                SoundManagerA.Instance.stopBGM(5);
                SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Normal);
                playerWalk_Sound.InstanceWalk.WalkSE_Change(playerWalk_Sound.WalkSE_List.HardFloor);
                break;
        }

        // 感情世界の削除
        base.DisappearanceWorld();
    }
}
