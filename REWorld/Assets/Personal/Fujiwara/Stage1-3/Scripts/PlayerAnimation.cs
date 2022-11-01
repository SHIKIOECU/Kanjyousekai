using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim = null;

    private Rigidbody2D rb = null;

    public GroundCheck ground;

    private bool r_run = true;
    private bool l_run = false;
    private bool isGround = false;
    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //girl = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = ground.IsGround();

        // 地面に接しているとき
        if (isGround)
        {
            // Spaceが押されたら
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
                isGround = false;

                /* test */
                anim.SetBool("isJumping", true);
            }
            // 何も押されていないとき
            else
            {
                /* test */
                anim.SetBool("isJumping", false);
            }
        }
        // ジャンプ中なら
        else if (isJump)
        {
            anim.SetBool("isJumping", true);

            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("right", true);
                anim.SetBool("left", false);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                /* test */
                anim.SetBool("left", true);
                anim.SetBool("right", false);
            }
        }

        // 右に歩くモーション
        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            /* test */
            anim.SetBool("isMoving", true);
            anim.SetBool("right", true);
            anim.SetBool("left", false);

            r_run = true;
            l_run = false;
        }
        // 左に歩くモーション
        else if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            /* test */
            anim.SetBool("isMoving", true);
            anim.SetBool("right", false);
            anim.SetBool("left", true);

            l_run = true;
            r_run = false;
        }
        // 止まってる時のモーション
        else
        {
            /* test */
            anim.SetBool("isMoving", false);
        }
    }
}
