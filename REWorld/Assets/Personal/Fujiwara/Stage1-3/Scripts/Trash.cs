using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IItem
{
    [SerializeField]
    private FlagData _trash;

    public bool isGet;

    public void ItemAction()
    {
        _trash.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
