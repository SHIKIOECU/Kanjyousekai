using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamelController : MonoBehaviour, INPC, IItem
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

    // 追従するターゲット
    [SerializeField] private HawkerController followTarget;
    [SerializeField] private DesertGirlController desertGirl;

    // サボテン
    [SerializeField] private GameObject cactus;
    [SerializeField] private GameObject big_cactus;

    // 移動スピード
    [SerializeField] private float speed;

    private float moveTime = 0;

    public bool isFollowing;
    public bool isEating;

    public Vector3 nowPos;

    // Start is called before the first frame update
    void Start()
    {
        Flag_Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing) FollowTarget();
        if (isEating) EatTarget();
    }

    public NPCData INPCData => NData;

    public GameObject EmotionalWorld => _emotionalWorld;

    public Sprite EmotionalWorldSprite => NData.Data.EmotionalWorldSprite;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => throw new System.NotImplementedException();

    public List<string> WordsText => throw new System.NotImplementedException();

    public void AppearanceWorld()
    {
        // 感情世界の表示
        _emotionalWorld.SetActive(true);

        // 現在位置の確保
        nowPos = transform.position;

        // 食べに行く処理 (追従してない & どっちかのサボテンを観測した後)
        //if (!isFollowing && (followTarget.onCactus || followTarget.onBigCactus)) isEating = true;
        isEating = true;

        isFollowing = false;

        // 移動後にスピードをゼロにする
        //if (!isEating && !isFollowing) moveTime = 0;
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        // 感情世界の削除
        _emotionalWorld.SetActive(false);

        isEating = false;
        isFollowing = true;
    }

    public void ItemAction()
    {
        throw new System.NotImplementedException();
    }

    // フラグの初期化
    private void Flag_Init()
    {
        isFollowing = true;
        isEating = false;
    }

    // 行商人に追従する処理
    private void FollowTarget()
    {
        //transform.position = new Vector2(followTarget.transform.position.x - 2.5f, transform.position.y);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(followTarget.transform.position.x - 2.5f, transform.position.y), (speed * 20) * Time.deltaTime);
    }

    // 移動関係の処理
    private void EatTarget()
    {
        if(!isFollowing && (followTarget.onCactus || followTarget.onBigCactus))
        {
            moveTime += speed * Time.deltaTime;

            // cactusを観測したとき
            if (followTarget.onCactus && !followTarget.onBigCactus)
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
                    desertGirl.INPCData.SetFlag("frightening");

                    // 移動速度のリセット
                    moveTime = 0;

                    // cactusの削除
                    cactus.SetActive(false);
                }
            }
            // big_cactusを観測したとき & 少女を観測していたら
            else if (followTarget.onBigCactus && desertGirl.moved && desertGirl.isDesertGirl)
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
                }
            }
        }
    }
}
