using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesertGirlController : MonoBehaviour, INPC
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

    // Animatorの取得
    public Animator desert_girl_anim;

    // ラクダの取得
    [SerializeField] CamelController camel;

    // ラクダの変更前の大きさ
    private Vector3 nowScale;

    private Vector3 big_camel_scale = new Vector3(8, 8, 1);     // ラクダの変更後の大きさ
    private Vector3 nowPos;                                     // 初期位置
    private Vector3 targetPos = new Vector3(22, -2.5f, 0);      // 目的位置

    [SerializeField] float speed;
    private float moveTime;

    public bool isMoving = false;
    public bool isDesertGirl = false;
    public bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        nowPos = transform.position;
        nowScale = camel.transform.localScale;

        _emotionalWorld.SetActive(false);

        FlagInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) MoveToTarget();
        if (isDesertGirl && moved && !camel.isEating && camel.isFollowing)
        {
            camel.isEating = true;
            camel.isFollowing = false;
        }
    }

    public NPCData INPCData => NData;

    public GameObject EmotionalWorld => _emotionalWorld;

    public Sprite EmotionalWorldSprite => NData.Data.EmotionalWorldSprite;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => throw new System.NotImplementedException();

    public List<string> WordsText => throw new System.NotImplementedException();

    public GameObject MaskSprite => throw new System.NotImplementedException();

    public void AppearanceWorld()
    {
        _emotionalWorld.SetActive(true);
        isDesertGirl = true;

        switch (NData.Data.Name)
        {
            case "frightening":
                desert_girl_anim.SetBool("isBigFrightening", true);
                camel.transform.localScale = big_camel_scale;
                camel.transform.position = new Vector3(camel.transform.position.x, 0, 0);
                camel.isFollowing = false;
                if (moved) camel.isEating = true; camel.nowPos = camel.transform.position;
                break;
            case "happy":
                break;
        }
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        _emotionalWorld.SetActive(false);
        isDesertGirl = false;
        moveTime = 0;
        camel.isFollowing = true;

        switch (NData.Data.Name)
        {
            case "frightening":
                desert_girl_anim.SetBool("isBigFrightening", false);
                camel.transform.localScale = nowScale;
                camel.transform.position = new Vector3(camel.transform.position.x, -1.75f, 0);
                //camel.isFollowing = true;
                break;
            case "happy":
                break;
        }
    }

    private void FlagInit()
    {
        isMoving = false;
        isDesertGirl = false;
        moved = false;
    }

    private void MoveToTarget()
    {
        moveTime += speed * Time.deltaTime;

        if (transform.position != targetPos)
        {
            transform.position = Vector3.Lerp(nowPos, targetPos, moveTime);
        }
        // 目的地まで着いたら
        else
        {
            isMoving = false;
            moved = true;
            moveTime = 0;
        }
    }
}
