using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl_EffectChange : MonoBehaviour
{
    [Header("変化前")]
    [SerializeField]
    GameObject Before_Girl;

    [Header("変化後")]
    [SerializeField]
    GameObject After_Girl;

    Girl girl;
    private bool IsIce;

    // Start is called before the first frame update
    void Start()
    {
        girl = GetComponent<Girl>();
    }

    // Update is called once per frame
    void Update()
    {
        IsIce = girl._getIce;

        if (IsIce == true)
        {
            Before_Girl.SetActive(false);
            After_Girl.SetActive(true);
        }
        else if (IsIce == false)
        {
            Before_Girl.SetActive(true);
            After_Girl.SetActive(false);
        }
    }
}
