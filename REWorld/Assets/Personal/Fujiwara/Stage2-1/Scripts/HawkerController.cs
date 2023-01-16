using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class HawkerController : NPCBase
{
    public enum HawkerState
    {
        STAND, DANCE, HYPERDANCE
    }
    public HawkerState State;

    // ラクダ
    [SerializeField] private GameObject camel;

    // 行商人のアニメーター
    [SerializeField] private Animator hawker_anim;

    // 移動スピード
    [SerializeField] private float speed;

    // 移動先のターゲット
    [SerializeField] private GameObject cactus;
    [SerializeField] private GameObject big_cactus;

    public bool onCactus, onBigCactus, moved;
    public bool movingToCactus;

    float Movetime = 0;

    public Vector3 nowPos;

    // Start is called before the first frame update
    void Start()
    {
        Flag_Init();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationChange();
        //Debug.Log("nowPos:" + nowPos);
        //Debug.Log("moved:" + moved);

        if (moved) Move();
    }

    public override int WordTerm()
    {
        return (int)State;
    }

    public override void AppearanceWorld()
    {
        // 感情世界の表示
        base.AppearanceWorld();

        if (!movingToCactus) {
            movingToCactus = true;
            moved = true;
            cactus.GetComponent<CactusController>().cactus_anim.SetBool("isDancing", true);
        }
    }

    //public override void ChangeWorld()
    //{
    //    throw new System.NotImplementedException();
    //}

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();
    }

    // 動かす処理
    private void Move()
    {
        if (camel.GetComponent<CamelController>().ateCactus)
        {
            MoveToPlace(camel, 2.5f);
        }
        else if (onBigCactus)
        {
            MoveToPlace(big_cactus, -2.5f);
        }
        else if (movingToCactus)
        {
            MoveToPlace(cactus, -2.5f);
        }
    }

    // 特定の位置に移動する処理
    public void MoveToPlace(GameObject target_place, float distance)
    {
        Movetime += speed * Time.deltaTime;
        if (transform.position != new Vector3(target_place.transform.position.x + distance, transform.position.y))
        {
            transform.position = Vector3.Lerp(nowPos, new Vector3(target_place.transform.position.x + distance, transform.position.y), Movetime);
        }
        else
        {
            moved = false;
            Movetime = 0;
            nowPos = this.gameObject.transform.position;
            if (movingToCactus) cactus.GetComponent<CactusController>().cactus_anim.SetBool("isDancing", false);
        }
    }

    // フラグの初期化
    private void Flag_Init()
    {
        onCactus = false;
        onBigCactus = false;
        moved = false;
        movingToCactus = false;
        nowPos = this.gameObject.transform.position;
    }

    // アニメーション関係の処理
    private void AnimationChange()
    {
        // cactusを観測したときの処理
        if (movingToCactus)
        {
            switch (moved)
            {
                case true:
                    hawker_anim.SetBool("isDancing", true);
                    break;
                case false:
                    hawker_anim.SetBool("isDancing", false);
                    Movetime = 0;
                    break;
            }
        }
        // big_cactusを観測した時の処理
        else if (onBigCactus)
        {
            switch (big_cactus.GetComponent<BigCactusController>().isBigCactusKansoku)
            {
                case true:
                    hawker_anim.SetBool("isSuperDancing", true);
                    break;
                case false:
                    hawker_anim.SetBool("isSuperDancing", false);
                    Movetime = 0;
                    break;
            }
        }
    }
}
