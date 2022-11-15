using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,IItem
{
    [SerializeField]
    private FlagData _coin;

    public bool isGet;

    public void ItemAction()
    {
        _coin.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }

}
