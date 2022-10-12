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
                Debug.Log("ジャンプ中です");

                isJump = true;
                isGround = false;
                //anim.SetBool("isGround", false);

                /* test */
                anim.SetBool("isJumping", true);

                // 右向きなら
                //if (r_run)
                //{
                //    //Debug.Log("r_jump");
                //    //anim.SetBool("r_jump", true);
                //    //anim.SetBool("l_jump", false);

                //    anim.SetBool("right", true);
                //    anim.SetBool("left", false);
                //}
                //// 左向きなら
                //else if (l_run) {
                //    //Debug.Log("l_jump");
                //    //anim.SetBool("l_jump", true);
                //    //anim.SetBool("r_jump", false);

                //    anim.SetBool("left", true);
                //    anim.SetBool("right", false);
                //}
            }
            // 何も押されていないとき
            else
            {
                //Debug.Log("地面と接しています");

                //anim.SetBool("isGround", true);

                /* test */
                anim.SetBool("isJumping", false);

                //isJump = false;

                //if (r_run) {
                //    anim.SetBool("r_jump", false);
                //    anim.SetBool("r_run", true);
                //}
                //else if (l_run) {
                //    anim.SetBool("l_jump", false);
                //    anim.SetBool("l_run", true);
                //}
            }
        }
        // ジャンプ中なら
        else if (isJump)
        {
            //anim.SetBool("isGround", false);
            anim.SetBool("isJumping", true);

            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                //anim.SetBool("r_jump", true);
                //anim.SetBool("l_jump", false);
                //anim.SetBool("r_run", true);
                //anim.SetBool("l_run", false);

                /* test */
                //anim.SetBool("isJumping", true);
                anim.SetBool("right", true);
                anim.SetBool("left", false);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                //anim.SetBool("r_jump", false);
                //anim.SetBool("l_jump", true);
                //anim.SetBool("r_run", false);
                //anim.SetBool("l_run", true);

                /* test */
                anim.SetBool("left", true);
                anim.SetBool("right", false);
            }
        }

        // 右に歩くモーション
        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            //anim.SetBool("r_run", true);
            //anim.SetBool("l_run", false);

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
            //anim.SetBool("l_run", true);
            //anim.SetBool("r_run", false);

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
            //if (r_run)
            //{
            //    anim.SetBool("r_run", false);
            //}
            //else if (l_run)
            //{
            //    anim.SetBool("l_run", false);
            //}

            /* test */
            anim.SetBool("isMoving", false);
        }

        if (UnityEngine.Input.GetKey(KeyCode.R))
        {
            anim.SetBool("kanjo", true);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.T))
        {
            anim.SetBool("kanjo", false);
        }
    }
}
