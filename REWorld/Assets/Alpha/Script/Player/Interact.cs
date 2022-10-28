using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public static Interact instance;

    //アイテムフラグリスト
    [SerializeField]
    private FlagList _itemFlagList;

    private IItem _item;

    private INPC _NPC;
    public INPC nowKansoku;

    //
    public bool isGet;

    public bool OnKansoku;

    public bool isKansoku=false;

    public bool isWorld;

    //ボタンが押されているか
    public bool OnGet;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _item = collision.gameObject.GetComponent<IItem>();
        _NPC = collision.gameObject.GetComponent<INPC>();

        if (_item != null && OnGet && !isGet)
        {
            _item.ItemAction();
            isGet = true;
        }

        //観測
        if (_NPC != null && OnKansoku && !isKansoku)
        {
            isKansoku = true;
            _NPC.AppearanceWorld();
            if (nowKansoku != null) nowKansoku.DisappearanceWorld();
            if (_NPC == nowKansoku)
            {
                nowKansoku = null;
            }
            else
            {
                nowKansoku = _NPC;
            }

            
            Debug.LogFormat(collision.gameObject.name);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _item = null;
        _NPC = null;

    }

}
