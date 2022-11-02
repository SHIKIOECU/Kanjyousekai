using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectChange : MonoBehaviour
{
    /*[Header("いつでも発生するエフェクト")]
    [SerializeField]
    ParticleSystem NormalEffect;*/

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

    IceClerk iceClerk;
    private bool IsJumping;

    // Start is called before the first frame update
    void Start()
    {
        iceClerk = GetComponent<IceClerk>();
    }

    // Update is called once per frame
    void Update()
    {
        IsJumping = iceClerk.jumping;

        if(IsJumping == true)
        {
            BeforeEffect.SetActive(false);
            BeforeSprite.SetActive(false);
            AfterEffect.SetActive(true);
            AfterSprite.SetActive(true);
        }
        else if (IsJumping == false)
        {
            BeforeEffect.SetActive(true);
            BeforeSprite.SetActive(true);
            AfterEffect.SetActive(false);
            AfterSprite.SetActive(false);
        }
    }
}
