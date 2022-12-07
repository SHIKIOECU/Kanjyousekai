using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IItem
{
    [SerializeField]
    private FlagData _key;

    public bool isGet;

    public void ItemAction()
    {
        _key.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
