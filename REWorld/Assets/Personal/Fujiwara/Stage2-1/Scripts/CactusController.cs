using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CactusController : MonoBehaviour, INPC
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

    [SerializeField] Animator cactus_anim;

    public bool isCactusKansoku;

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

    public void AppearanceWorld()
    {
        //Debug.Log("cactusが観測されました");
        _emotionalWorld.SetActive(true);

        cactus_anim.SetBool("isDancing", true);

        hawker.nowPos = hawker.transform.position;

        hawker.moved = true;
        hawker.onCactus = true;
        camel.isFollowing = true;
        isCactusKansoku = true;
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        _emotionalWorld.SetActive(false);

        cactus_anim.SetBool("isDancing", false);

        //hawker.onCactus = false;
        camel.isFollowing = false;
        isCactusKansoku = false;
        hawker.moved = false;
        //Debug.Log("cactusの感情世界を消しました");
    }

    
}
