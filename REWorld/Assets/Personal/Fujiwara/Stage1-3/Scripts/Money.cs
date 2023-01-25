using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour, IItem
{
    [SerializeField]
    private ItemData _money;

    public bool isGet;

    public void ItemAction()
    {
        _money.SetItemStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
