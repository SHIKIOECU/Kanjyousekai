using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigCactusController : MonoBehaviour, INPC
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

    [SerializeField] HawkerController hawker;
    [SerializeField] CamelController camel;
    [SerializeField] DesertGirlController desertGirl;

    [SerializeField] Animator big_cactus_anim;

    public bool isBigCactusKansoku;

    // Start is called before the first frame update
    void Start()
    {
        _emotionalWorld.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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
        // 感情世界の表示
        _emotionalWorld.SetActive(true);

        // 自分を踊り状態にする
        big_cactus_anim.SetBool("isDancing", true);

        // 少女を踊り状態にする
        desertGirl.desert_girl_anim.SetBool("isHappy", true);
        desertGirl.INPCData.SetFlag("happy");

        hawker.nowPos = hawker.transform.position;
        
        hawker.moved = true;
        hawker.onBigCactus = true;
        camel.isFollowing = true;
        desertGirl.isMoving = true;

        isBigCactusKansoku = true;
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        _emotionalWorld.SetActive(false);

        // 自分を通常の状態に戻す
        big_cactus_anim.SetBool("isDancing", false);

        // 少女を怯え状態に戻す
        desertGirl.INPCData.SetFlag("frightening");
        desertGirl.desert_girl_anim.SetBool("isHappy", false);

        //hawker.onBigCactus = false;
        camel.isFollowing = false;
        isBigCactusKansoku = false;
        hawker.moved = false;
        desertGirl.isMoving = false;
    }
}
