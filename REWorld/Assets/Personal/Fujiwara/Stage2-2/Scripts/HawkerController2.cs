using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HawkerController2 : MonoBehaviour, INPC
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

    void Start()
    {
        _emotionalWorld.SetActive(false);
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

    public void AppearanceWorld()
    {
        _emotionalWorld.SetActive(true);
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        _emotionalWorld.SetActive(false);
    }
}
