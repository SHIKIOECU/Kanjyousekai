using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class FatherController : NPCBase
{
    public enum FatherState
    {
        FLUSTERED, MOVE, SHOUT
    }
    public FatherState State;

    // LostBoyの取得
    [SerializeField] GameObject lostBoy;

    // Canvasの取得
    [SerializeField] GameObject canvas;

    // spriteの取得
    [SerializeField] Sprite[] fatherSprites;

    SpriteRenderer fatherSprite;

    // ポジション
    Vector3 nowPos = new Vector3(19.1f, 1.31f, 0.0f);
    Vector3 targetPos = new Vector3(37.0f, 1.31f, 0.0f);

    float distance_nowtotarget;

    // 移動スピード
    [SerializeField] float speed;
    float nowSpeed;

    // 達成項目のフラグの取得
    [SerializeField] FlagData challenge2flag;
    [SerializeField] FlagData challenge3flag;

    // 観測されたどうか
    public bool isFather;

    //static public bool challenge2flag, challenge3flag;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        isFather = true;
        distance_nowtotarget = Vector3.Distance(nowPos, targetPos);

        challenge2flag.SetFlagStatus();
        //challenge2flag = true;

        fatherSprite = gameObject.GetComponent<SpriteRenderer>();
        fatherSprite.sprite = fatherSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (lostBoy.GetComponent<LostBoyController>().isFather) MoveToBoy();

        if (lostBoy.GetComponent<LostBoyController>().isReunion)
        {
            canvas.SetActive(false);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            canvas.SetActive(true);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public override int WordTerm()
    {
        return (int)State;
    }

    void MoveToBoy()
    {
        if (fatherSprite != fatherSprites[2]) fatherSprite.sprite = fatherSprites[2];

        nowSpeed += Time.deltaTime * speed;
        float current_pos = nowSpeed / distance_nowtotarget;

        transform.position = Vector3.Slerp(nowPos, targetPos, current_pos);

        if (transform.position.x >= targetPos.x - 0.1f)
        {
            isFather = false;
            lostBoy.GetComponent<LostBoyController>().isReunion = true;

            challenge3flag.SetFlagStatus();
            //challenge3flag = true;

            fatherSprite.sprite = fatherSprites[0];

            //gameObject.SetActive(false);
        }
    }

    public override void AppearanceWorld()
    {
        SetNPCData("scary");
        fatherSprite.sprite = fatherSprites[1];

        SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Angry);

        base.AppearanceWorld();
    }

    public override void DisappearanceWorld()
    {
        SetNPCData("basic");
        fatherSprite.sprite = fatherSprites[0];

        SoundManagerA.Instance.ChangeBGM(SoundManagerA.BGM_List.Normal);

        base.DisappearanceWorld();
    }
}
