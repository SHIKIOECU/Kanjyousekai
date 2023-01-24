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

    int trashcnt = 0;

    public void ItemAction()
    {
        trashcnt = aunt.TrashCount();
        aunt.AuntChangeWord(trashcnt);
        _trash.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
