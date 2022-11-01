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

    public bool isBigCactusKansoku;

    // Start is called before the first frame update
    void Start()
    {

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

    public void AppearanceWorld()
    {
        //Debug.Log("big_cactusが観測されました");

        _emotionalWorld.SetActive(true);

        hawker.nowPos = hawker.transform.position;

        hawker.moved = true;
        hawker.onBigCactus = true;
        camel.isFollowing = true;
        isBigCactusKansoku = true;
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        _emotionalWorld.SetActive(false);
        //hawker.onBigCactus = false;
        camel.isFollowing = false;
        isBigCactusKansoku = false;
    }
}
