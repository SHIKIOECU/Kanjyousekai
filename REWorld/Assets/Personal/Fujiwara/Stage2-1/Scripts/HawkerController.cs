using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HawkerController : MonoBehaviour, INPC, IItem
{
    //NPCData
    [SerializeField]
    private NPCData NData;

    //感情世界
    [SerializeField]
    private GameObject _emotionalWorld;

    //グラフィック
    [SerializeField]
    private SpriteRenderer _NPC;

    //セリフ
    [SerializeField]
    private Text _words;

    //セリフテキスト
    [SerializeField]
    private List<string> _wordsText;

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

    public NPCData INPCData => NData;

    public GameObject EmotionalWorld => throw new System.NotImplementedException();

    public Sprite EmotionalWorldSprite => throw new System.NotImplementedException();

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => throw new System.NotImplementedException();

    public List<string> WordsText => throw new System.NotImplementedException();

    public void AppearanceWorld()
    {
        
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        throw new System.NotImplementedException();
    }

    public void ItemAction()
    {
        throw new System.NotImplementedException();
    }

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
        if (transform.position != new Vector3(target_place.transform.position.x - 2.5f, transform.position.y))
        {
            transform.position = Vector3.Lerp(nowPos, new Vector3(target_place.transform.position.x - 2.5f, transform.position.y), Movetime);
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
                    //Debug.Log("isDancingをtrueにしました");
                    hawker_anim.SetBool("isDancing", true);
                    break;
                case false:
                    //Debug.Log("isDancingをfalseにしました");
                    hawker_anim.SetBool("isDancing", false);
                    break;
            }
        }
        // big_cactusを観測した時の処理
        else if (onBigCactus)
        {
            switch (big_cactus.GetComponent<BigCactusController>().isBigCactusKansoku)
            {
                case true:
                    //Debug.Log("isSuperDancingをtrueにしました");
                    hawker_anim.SetBool("isSuperDancing", true);
                    break;
                case false:
                    //Debug.Log("isSuperDancingをfalseにしました");
                    hawker_anim.SetBool("isSuperDancing", false);
                    break;
            }
        }
    }
}
