using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractMessage, IItem
{
    [SerializeField]
    //private ItemData _key;
    private FlagData _key;

    //[SerializeField] GameObject key_obj;

    public bool isGet;

    public void ItemAction()
    {
        _key.SetFlagStatus();
        //key_obj.SetActive(true);
        //_key.SetItemStatus();
        //_key.SetItemStatus();
        //_key.Count = 2;
        isGet = true;
        gameObject.SetActive(false);
    }
}
