using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class HawkerController : NPCBase
{
    // ラクダ
    [SerializeField] private CamelController camel;

    // 行商人のアニメーター
    [SerializeField] private Animator hawker_anim;

    // 移動スピード
    [SerializeField] private float speed;

    // 移動先のターゲット
    [SerializeField] private GameObject cactus;
    [SerializeField] private GameObject big_cactus;

    public bool onCactus, onBigCactus, moved;

    float Movetime = 0;

    public Vector3 nowPos;

    // Start is called before the first frame update
    void Start()
    {
        Flag_Init();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationChange();
        //Debug.Log("nowPos:" + nowPos);
        //Debug.Log("moved:" + moved);

        if (moved) Move();
    }

    //public orverride void AppearanceWorld()
    //{
        
    //}

    //public override void ChangeWorld()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override void DisappearanceWorld()
    //{
    //    throw new System.NotImplementedException();
    //}

    // 動かす処理
    private void Move()
    {
        if (onCactus && !onBigCactus)
        {
            //hawker_anim.SetBool("isDancing", true);
            MoveToPlace(cactus);
            //Debug.LogFormat("nowPos:{0}, targetPos:{1}", nowPos, cactus.transform.position);
        }
        else if (onBigCactus) {
            //hawker_anim.SetBool("isSuperDancing", true);
            MoveToPlace(big_cactus);
            //Debug.LogFormat("nowPos:{0}, targetPos:{1}", nowPos, big_cactus.transform.position);
        }
    }

    // 特定の位置に移動する処理
    public void MoveToPlace(GameObject target_place)
    {
        Movetime += speed * Time.deltaTime;
        if (transform.position != new Vector3(target_place.transform.position.x - 3.5f, transform.position.y))
        {
            transform.position = Vector3.Lerp(nowPos, new Vector3(target_place.transform.position.x - 3.5f, transform.position.y), Movetime);
        }
        else
        {
            moved = false;
            Movetime = 0;

            //if (target_place == cactus) hawker_anim.SetBool("isDancing", false);
            //else if (target_place == big_cactus) hawker_anim.SetBool("isSuperDancing", false);
        }
    }

    // フラグの初期化
    private void Flag_Init()
    {
        onCactus = false;
        onBigCactus = false;
        moved = false;
    }

    // アニメーション関係の処理
    private void AnimationChange()
    {
        // cactusを観測したときの処理
        if (onCactus && !onBigCactus)
        {
            switch (cactus.GetComponent<CactusController>().isCactusKansoku)
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
