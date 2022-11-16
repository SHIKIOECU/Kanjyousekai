using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContrarianController : MonoBehaviour, INPC
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

    // NPCの取得
    [SerializeField] HawkerController2 hawker;
    [SerializeField] GorillaController gorilla;

    void Start()
    {
        _emotionalWorld.SetActive(false);
        gorilla.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    void Update()
    {

    }

    public NPCData INPCData => NData;

    public GameObject EmotionalWorld => _emotionalWorld;

    public Sprite EmotionalWorldSprite => INPCData.Data.EmotionalWorldSprite;

    public SpriteRenderer NPCSprite => _NPC;

    public Text Words => throw new System.NotImplementedException();

    public List<string> WordsText => throw new System.NotImplementedException();

    public GameObject MaskSprite => throw new System.NotImplementedException();

    public void AppearanceWorld()
    {
        // 感情世界の表示
        _emotionalWorld.SetActive(true);

        // ゴリラのisTriggerをtrueにする
        //gorillaCollider.isTrigger = true;
        gorilla.GetComponent<BoxCollider2D>().isTrigger = true;

        // NPCのステータスを変更する
        hawker.INPCData.SetFlag("cold");
        gorilla.INPCData.SetFlag("sleep");
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        // 感情世界の削除
        _emotionalWorld.SetActive(false);

        // ゴリラのisTriggerをfalseにする
        //gorillaCollider.isTrigger = false;
        gorilla.GetComponent<BoxCollider2D>().isTrigger = false;

        // NPCのステータスを変更する
        hawker.INPCData.SetFlag("basic");
        gorilla.INPCData.SetFlag("basic");
    }
}
