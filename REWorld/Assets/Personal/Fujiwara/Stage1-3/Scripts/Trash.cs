using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IItem
{
    [SerializeField]
    private FlagData _trash;

    [SerializeField]
    AuntController aunt;

    public bool isGet;

    public void ItemAction()
    {
        aunt.TrashCount();
        _trash.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
