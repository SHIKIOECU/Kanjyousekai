using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectChange : MonoBehaviour
{
    /*[Header("いつでも発生するエフェクト")]
    [SerializeField]
    ParticleSystem NormalEffect;*/

    [Header("変化前")]
    [SerializeField]
    GameObject Before_IceClerk;

    [Header("変化後")]
    [SerializeField]
    GameObject After_IceClerk;

    [Header("カンジョウ世界消滅時のエフェクト")]
    [SerializeField]
    GameObject DisappearEffect;

    IceClerk iceClerk;

    //private bool kanjou;

    [SerializeField]
    GameObject EmotionalWorld;

    // Start is called before the first frame update
    void Start()
    {
        iceClerk = GetComponent<IceClerk>();

        DisappearEffect.SetActive(false);
        //kanjou = Interact.instance.isKansoku;
    }

    // Update is called once per frame
    void Update()
    {
        if (EmotionalWorld.activeSelf == true)
        {
            DisappearEffect.SetActive(false);
            if (iceClerk.INPCData.Name == "happy")
            {
                Before_IceClerk.SetActive(false);
                After_IceClerk.SetActive(true);
            }
            else if (iceClerk.INPCData.Name == "basic")
            {
                Before_IceClerk.SetActive(true);
                After_IceClerk.SetActive(false);
            }
        }
        else
        {
            DisappearEffect.SetActive(true);
            Before_IceClerk.SetActive(false);
            After_IceClerk.SetActive(false);
        }
    }
}
