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

    [SerializeField] private Canvas _interactCanvas;
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

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _itemFlagList.InitFlags();
        _interactCanvas.enabled = false;
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
        Debug.Log(_NPC);

        switch (collision.tag)
        {
            default:
                break;
        }

        GetItem();

        //観測
        Kansoku();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _item = null;

    }

    private void ShowInteractCanvas(bool value = true)
    {
        _interactCanvas.enabled = value;
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
        if (_item != null)
        {
            //ボタンを押されていない時にインタラクトキャンバスを表示
            if (!OnGet) ShowInteractCanvas();
            else if (!isGet)
            {
                ShowInteractCanvas(false);
                _item.ItemAction();
                isGet = true;
            }
        }
    }

    private void ChangeInteractCanvas()
    {
        if (_item == null && _NPC == null)
        {
            ShowInteractCanvas(false);
            return;
        }

        if (_item != null && _NPC != null)
        {
            ShowInteractCanvas();
        }

    }
}
