using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBox : InteractMessage, IItem
{
    // trashの数
    int trashCount;

    // ゴミのフラグ
    [SerializeField] GameObject[] trashes;

    // Auntの取得
    [SerializeField] AuntController aunt;

    [SerializeField] private ItemData _trash;

    // Start is called before the first frame update
    void Start()
    {
        trashCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool CheckTrashFlagData()
    {
        trashCount = 0;

        foreach (GameObject trash in trashes)
        {
            if (trash.GetComponent<Trash>().isGet) trashCount++;
        }

        if (trashCount < 3) return false;
        else return true;
    }

    public void ItemAction()
    {
        if (CheckTrashFlagData()) {
            aunt.isAllPickUp = true;
            for(int i = 0;i<trashCount;i++)
            {
                _trash.SetItemStatus(false);
            }
            aunt.SetNPCData("happy");
        }
    }
}
