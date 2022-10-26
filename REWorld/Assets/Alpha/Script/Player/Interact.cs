using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public static Interact instance;

    //アイテムフラグリスト
    [SerializeField]
    private FlagList _itemFlagList;

    public IItem _item;

    public INPC _NPC;

    //
    public bool isGet;

    public bool OnKansoku;

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
        if (_NPC != null && OnKansoku && !isWorld)
        {
            _NPC.SetActiveWorld();
            isWorld = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("World"))
        {
            isWorld = false;
            collision.gameObject.SetActive(false);
        }

        _item = null;
        _NPC = null;

    }

}
