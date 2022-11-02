using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl_EffectChange : MonoBehaviour
{
    [Header("変化前のエフェクト")]
    [SerializeField]
    GameObject BeforeEffect;

    [Header("変化前の背景")]
    [SerializeField]
    GameObject BeforeSprite;

    [Header("変化後のエフェクト")]
    [SerializeField]
    GameObject AfterEffect;

    [Header("変化後の背景")]
    [SerializeField]
    GameObject AfterSprite;

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
            BeforeEffect.SetActive(false);
            BeforeSprite.SetActive(false);
            AfterEffect.SetActive(true);
            AfterSprite.SetActive(true);
        }
        else if (IsIce == false)
        {
            BeforeEffect.SetActive(true);
            BeforeSprite.SetActive(true);
            AfterEffect.SetActive(false);
            AfterSprite.SetActive(false);
        }
    }
}
