using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : MonoBehaviour, IItem
{
    // NPCの取得
    [SerializeField] GameObject npc;

    // 鍵フラグの取得
    [SerializeField] Key key;

    // Start is called before the first frame update
    void Start()
    {
        npc.SetActive(false);
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
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
