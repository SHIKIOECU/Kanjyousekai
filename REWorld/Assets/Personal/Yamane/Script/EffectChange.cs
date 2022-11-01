using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectChange : MonoBehaviour
{
    [Header("いつでも発生するエフェクト")]
    [SerializeField]
    ParticleSystem NormalEffect;

    /*[Header("変化前のエフェクト")]
    [SerializeField]
    ParticleSystem BeforeEffect;*/

    /*[Header("変化後のエフェクト")]
    [SerializeField]
    ParticleSystem AfterEffect;*/

    //コライダーのサイズ
    private float objectRadius;

    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        objectRadius = collider.radius;

        var sh = NormalEffect.shape;
        sh.radius = objectRadius;

        Instantiate(NormalEffect, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
