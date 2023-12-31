using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class CamelController : NPCBase, IItem
{
    public enum CamelState
    {
        STAND, DANCE, EAT
    }
    public CamelState State;

    // 追従するターゲット
    [SerializeField] private HawkerController followTarget;
    [SerializeField] private DesertGirlController desertGirl;

    // サボテン
    [SerializeField] private GameObject cactus;
    [SerializeField] private GameObject big_cactus;

    // フラグの取得
    [SerializeField] FlagData smallcactus;

    // 移動スピード
    [SerializeField] private float speed;

    private float moveTime = 0;

    public bool isFollowing;
    public bool isEating;
    public bool ateCactus;
    public bool isBig;

    public Vector3 nowPos;

    // Start is called before the first frame update
    void Start()
    {
        Flag_Init();
        base.DisappearanceWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing) FollowTarget();
        if (isEating) EatTarget();
    }

    public override int WordTerm()
    {
        return (int)State;
    }

    public override void AppearanceWorld()
    {
        // 感情世界の表示
        base.AppearanceWorld();

        // 現在位置の確保
        nowPos = transform.position;

        // 食べに行く処理 (追従してない & どっちかのサボテンを観測した後)
        //if (!isFollowing && (followTarget.onCactus || followTarget.onBigCactus)) isEating = true;
        isEating = true;

        isFollowing = false;
    }

    public override void DisappearanceWorld()
    {
        // 感情世界の削除
        base.DisappearanceWorld();

        isEating = false;
        isFollowing = true;
        ateCactus = false;
    }

    // フラグの初期化
    private void Flag_Init()
    {
        isFollowing = true;
        isEating = false;
        ateCactus = false;
    }

    // 行商人に追従する処理
    private void FollowTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(followTarget.transform.position.x - 2.5f, transform.position.y), (speed * 20) * Time.deltaTime);
    }

    // 移動関係の処理
    private void EatTarget()
    {
        if(!isFollowing)
        {
            moveTime += speed * Time.deltaTime;

            // big_cactusを観測したとき & 少女を観測していたら
            if (isBig)
            {
                if (transform.position != new Vector3(big_cactus.transform.position.x - 4, transform.position.y, 0))
                {
                    transform.position = Vector3.Lerp(nowPos, new Vector3(big_cactus.transform.position.x - 4, transform.position.y, 0), moveTime);
                }
                else
                {
                    isEating = false;
                    followTarget.onBigCactus = false;
                    //isFollowing = true;

                    // 移動速度のリセット
                    moveTime = 0;

                    big_cactus.SetActive(false);

                    ateCactus = true;
                    followTarget.moved = true;
                }
            }
            // cactusを食べに行くとき
            else if (followTarget.movingToCactus)
            {
                if (transform.position != new Vector3(cactus.transform.position.x - 2, transform.position.y, 0))
                {
                    //Debug.Log("cactusを食べに行きます");
                    transform.position = Vector3.Lerp(nowPos, new Vector3(cactus.transform.position.x - 2, transform.position.y, 0), moveTime);
                }
                else
                {
                    isEating = false;
                    followTarget.onCactus = false;
                    //isFollowing = true;

                    // 少女を怯え状態にする
                    desertGirl.desert_girl_anim.SetBool("isFrightening", true);
                    desertGirl.SetNPCData("frightening");

                    // 移動速度のリセット
                    moveTime = 0;

                    // cactusの削除
                    cactus.SetActive(false);

                    ateCactus = true;
                    followTarget.moved = true;
                }
            }
        }
    }

    public void ItemAction()
    {
        if (smallcactus.IsOn) SetNPCData("happy");
    }
}
