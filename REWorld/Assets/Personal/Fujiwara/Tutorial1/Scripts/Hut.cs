using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : InteractMessage, IItem
{
    // NPCの取得
    [SerializeField] GameObject npc;

    // 鍵フラグの取得
    //[SerializeField] ItemData key;
    [SerializeField] Key key;

    // 鎖の取得
    [SerializeField] GameObject chain;

    //[SerializeField]  key_obj;

    int unlockCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        npc.SetActive(false);
        chain.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemAction()
    {
        if (key.isGet)
        {
            npc.SetActive(true);
            chain.SetActive(false);
            //key.SetItemStatus(false);
            //unlockCnt++;
            //if (unlockCnt >= 2) key_obj.SetActive(false);
            //if (unlockCnt < 2) key.SetItemStatus();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
