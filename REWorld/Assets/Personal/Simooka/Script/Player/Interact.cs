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
    [SerializeField] private SpriteRenderer _interactFrame;
    [SerializeField] private SpriteRenderer _interactButton;
    [SerializeField] private Vector2 _interactCanvasPos;
    [SerializeField]private TextMeshProUGUI _text;
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
        _interactCanvas.enabled = false;
        _interactFrame.enabled = false;
        _interactButton.enabled = false;
        _text = _interactCanvas.transform.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

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
        ChangeInteractCanvas(_interactMessage.Message,_interactMessage.ButtonSprite);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _item = null;
        ShowInteractCanvas(false);
    }

    private void ShowInteractCanvas(bool value = true)
    {
        _interactCanvas.transform.position = _interactCanvasPos;
        _interactCanvas.enabled = value;
        _interactFrame.enabled= value;
        _interactButton.enabled= value;
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

    private void ChangeInteractCanvas(string message,Sprite sprite)
    {

        _text.text = message;
        _interactButton.sprite = sprite;
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
