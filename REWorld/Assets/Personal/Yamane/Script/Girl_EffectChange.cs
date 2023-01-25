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

    [Header("カンジョウ世界消滅時のエフェクト")]
    [SerializeField]
    GameObject DisappearEffect;

    Girl girl;
    private bool IsIce;

    //private bool kanjou;

    [SerializeField]
    GameObject EmotionalWorld;

    // Start is called before the first frame update
    void Start()
    {
        girl = GetComponent<Girl>();

        DisappearEffect.SetActive(false);
        //kanjou = Interact.instance.isKansoku;
    }

    // Update is called once per frame
    void Update()
    {
        IsIce = girl._getIce;

        if (EmotionalWorld.activeSelf == true)
        {
            DisappearEffect.SetActive(false);
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
        else
        {
            DisappearEffect.SetActive(true);
            Before_Girl.SetActive(false);
            After_Girl.SetActive(false);
        }
    }
}
