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
            if (UnityEngine.Input.GetKey(KeyCode.Space))
            {
                Debug.Log("ジャンプ中です");

                isJump = true;
                isGround = false;
                anim.SetBool("isGround", false);

                // 右向きなら
                if (r_run)
                {
                    Debug.Log("r_jump");
                    anim.SetBool("r_jump", true);
                    anim.SetBool("l_jump", false);
                }
                // 左向きなら
                else if (l_run) {
                    Debug.Log("l_jump");
                    anim.SetBool("l_jump", true);
                    anim.SetBool("r_jump", false);
                }
            }
            // 何も押されていないとき
            else
            {
                //Debug.Log("地面と接しています");

                anim.SetBool("isGround", true);

                isJump = false;

                if (r_run) {
                    anim.SetBool("r_jump", false);
                    anim.SetBool("r_run", true);
                }
                else if (l_run) {
                    anim.SetBool("l_jump", false);
                    anim.SetBool("l_run", true);
                }
            }
        }
        // ジャンプ中なら
        else if (isJump)
        {
            anim.SetBool("isGround", false);

            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("r_jump", true);
                anim.SetBool("l_jump", false);
                anim.SetBool("r_run", true);
                anim.SetBool("l_run", false);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("r_jump", false);
                anim.SetBool("l_jump", true);
                anim.SetBool("r_run", false);
                anim.SetBool("l_run", true);
            }
        }

        // 右に歩くモーション
        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("r_run", true);
            anim.SetBool("l_run", false);
            r_run = true;
            l_run = false;
        }
        // 左に歩くモーション
        else if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("l_run", true);
            anim.SetBool("r_run", false);
            l_run = true;
            r_run = false;
        }
        // 止まってる時のモーション
        else
        {
            if (r_run)
            {
                anim.SetBool("r_run", false);
            }
            else if (l_run)
            {
                anim.SetBool("l_run", false);
            }
        }

        //if (UnityEngine.Input.GetKey(KeyCode.R))
        //{
        //    anim.SetBool("kanjo", true);
        //}
        //else
        //{
        //    anim.SetBool("kanjo", false);
        //}
    }
}
