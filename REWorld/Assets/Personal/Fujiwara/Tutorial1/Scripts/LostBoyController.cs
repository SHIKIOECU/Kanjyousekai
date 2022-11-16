using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostBoyController : MonoBehaviour, INPC
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

    // ボートの取得
    [SerializeField] GameObject boat;

    // ボートの移動先のポジション
    private Vector3 moveToPos = new Vector3(30, 0, 0);
    private Vector3 defaultPos;

    void Start()
    {
        // 感情世界の削除
        _emotionalWorld.SetActive(false);

        // ボートの現在の位置を取得
        defaultPos = boat.transform.position;
    }

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
        // 感情世界の表示
        _emotionalWorld.SetActive(true);

        // boatの位置を移動させて水を出現させる
        boat.transform.position = moveToPos;

        // LostGirlの状態を変化させる
        INPCData.SetFlag("cry");
    }

    public void ChangeWorld()
    {
        throw new System.NotImplementedException();
    }

    public void DisappearanceWorld()
    {
        // 感情世界の削除
        _emotionalWorld.SetActive(false);

        // boatの位置を元の位置に戻す
        boat.transform.position = defaultPos;

        // LostGirlの状態を変化させる
        INPCData.SetFlag("basic");
    }
}
