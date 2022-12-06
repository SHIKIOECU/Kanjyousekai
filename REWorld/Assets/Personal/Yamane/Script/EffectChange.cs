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

    IceClerk iceClerk;
    private bool IsJumping;

    //private bool kanjou;

    [SerializeField]
    GameObject EmotionalWorld;

    // Start is called before the first frame update
    void Start()
    {
        iceClerk = GetComponent<IceClerk>();

        //kanjou = Interact.instance.isKansoku;
    }

    // Update is called once per frame
    void Update()
    {
        IsJumping = iceClerk.jumping;

        if (EmotionalWorld.activeSelf == true)
        {
            if (IsJumping == true)
            {
                Before_IceClerk.SetActive(false);
                After_IceClerk.SetActive(true);
            }
            else if (IsJumping == false)
            {
                Before_IceClerk.SetActive(true);
                After_IceClerk.SetActive(false);
            }
        }
        else
        {
            Before_IceClerk.SetActive(false);
            After_IceClerk.SetActive(false);
        }
    }
}
