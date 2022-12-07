using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour, IItem
{
    [SerializeField]
    private FlagData _money;

    public bool isGet;

    public void ItemAction()
    {
        _money.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
