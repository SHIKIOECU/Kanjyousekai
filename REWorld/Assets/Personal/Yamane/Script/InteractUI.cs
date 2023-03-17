using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField]
    ItemData _itemData;

    [SerializeField]
    SpriteRenderer sp;

    private bool isGet;

    // Start is called before the first frame update
    void Start()
    {
        sp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGet = _itemData.IsOn;

        if(isGet == true)
        {
            sp.enabled = true;
        }
        else
        {
            sp.enabled = false;
        }
    }
}
