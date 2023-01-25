using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interact : Singleton<Interact>
{
    #region private変数
    //アイテムフラグリスト
    [SerializeField]
    private FlagList _itemFlagList;

    private IItem _item;

    private INPC _NPC;

    [SerializeField]private InteractMessage _interactMessage;
    [SerializeField] private Vector2 _plusPos;

    

    [SerializeField] private Canvas _interactCanvas;
    [SerializeField] private SpriteRenderer _npcInteractFrame;
    [SerializeField] private SpriteRenderer _npcInteractButton;
    [SerializeField]private TextMeshProUGUI _npcText;
    [SerializeField] private SpriteRenderer _itemInteractFrame;
    [SerializeField] private SpriteRenderer _itemInteractButton;
    [SerializeField] private TextMeshProUGUI _itemText;
    [SerializeField] private Vector2 _interactCanvasPos;
    #endregion

    #region public変数
    public INPC nowKansoku;

    //
    public bool isGet;

    public bool OnKansoku;

    public bool isKansoku=false;

    public bool isWorld;

    //ボタンが押されているか
    public bool OnGet;

    public enum InteractState
    {
        NONE,
        ITEM,
        NPC,NPC_ITEM
    }

    public InteractState State;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _itemFlagList.InitFlags();
        ShowInteractCanvas(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_item);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //_item = collision.gameObject.GetComponent<IItem>();
        //_NPC = collision.gameObject.GetComponent<INPC>();

        if(_NPC!=null) _NPC.ChangeWorld();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _item = collision.gameObject.GetComponent<IItem>();
        _NPC = collision.gameObject.GetComponent<INPC>();
        _interactMessage = collision.GetComponent<InteractMessage>();
        Debug.Log(_interactMessage);

        GetItem();

        //観測
        Kansoku();

        //ChangeState();
        if (_interactMessage == null) return;
        _interactCanvasPos =
            collision.gameObject.GetComponent<InteractMessage>().Space + _plusPos;
        ChangeInteractCanvas(_npcText,_npcInteractButton,_interactMessage.NPCMessage,_interactMessage.NPCButtonSprite);
        ChangeInteractCanvas(_itemText, _itemInteractButton, _interactMessage.ItemMessage, _interactMessage.ItemButtonSprite);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _item = null;
        ShowInteractCanvas(false);
    }

    private void ShowInteractCanvas(bool value = true)
    {
        _interactCanvas.transform.position = _interactCanvasPos;
        _npcInteractFrame.enabled= value;
        _itemInteractFrame.enabled= value;
        _interactCanvas.enabled = value;
        _npcInteractFrame.enabled = value;
        _npcInteractButton.enabled = value;
        _itemInteractFrame.enabled = value;
        _itemInteractButton.enabled = value;
    }

    //観測
    private void Kansoku()
    {
        if (_NPC != null && OnKansoku && !isKansoku)
        {
            isKansoku = true;

            //感情世界を出現させる
            _NPC.AppearanceWorld();
            PlayerAnimator.instance.SetKanjyo();

            //出現している感情世界があるなら消す
            if (nowKansoku != null)
            {
                nowKansoku.DisappearanceWorld();
                if (nowKansoku == _NPC) PlayerAnimator.instance.SetKanjyo(false);
            }
            Debug.Log(_NPC + " : " + nowKansoku);

            //出現している感情世界の情報を更新する
            if (nowKansoku == _NPC)
            {
                nowKansoku = null;
            }
            else
            {
                nowKansoku = _NPC;
            }
            Debug.Log(nowKansoku);
        }
    }

    private void GetItem()
    {
        if (_item != null && !isGet&&OnGet)
        {
                ShowInteractCanvas(false);
                _item.ItemAction();
                isGet = true;
        }
    }

    private void ChangeInteractCanvas(TextMeshProUGUI text,SpriteRenderer spriteRenderer,string message,Sprite sprite)
    {

        text.text = message;
        spriteRenderer.sprite = sprite;
        ShowInteractCanvas(true);
    }

    private void ChangeState()
    {
        if (_NPC == null && _item == null) State = InteractState.NONE;
        else if (_NPC == null) State = InteractState.ITEM;
        else if (_item == null) State = InteractState.NPC;
        else State = InteractState.NPC_ITEM;
    }
}
