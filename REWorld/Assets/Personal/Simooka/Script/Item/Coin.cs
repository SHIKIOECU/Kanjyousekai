using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,IItem
{
    [SerializeField]
    private ItemData _coin;

    public bool isGet;

    public void ItemAction()
    {
        _coin.SetItemStatus();
        isGet = true;
        gameObject.SetActive(false);
    }

}
