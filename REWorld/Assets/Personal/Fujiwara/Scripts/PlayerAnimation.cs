using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim = null;
    public Animator girl = null;

    private Rigidbody2D rb = null;

    public GroundCheck ground;

    private bool r_run = true;
    private bool l_run = false;
    private bool isGround = false;
    private bool isJump = false;

    public float speed;
    public float gravity;
    public float jumpSpeed;
    public float jumpHeight;
    public float jumpPos = 0.0f;

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

        //float xSpeed = 0.0f;
        //float ySpeed = -gravity;

        if (isGround)
        {
            if (UnityEngine.Input.GetKey(KeyCode.Space))
            {
                Debug.Log("ジャンプ中です");

                //ySpeed = jumpSpeed;
                jumpPos = transform.position.y;
                isJump = true;
                isGround = false;

                if (r_run)
                {
                    Debug.Log("r_jump");
                    anim.SetBool("r_jump", true);
                    anim.SetBool("l_jump", false);
                }
                else if (l_run) {
                    Debug.Log("l_jump");
                    anim.SetBool("l_jump", true);
                    anim.SetBool("r_jump", false);
                }
            }
            else
            {
                Debug.Log("地面と接しています");

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
        else if (isJump)
        {
            if (UnityEngine.Input.GetKey(KeyCode.Space) && jumpPos + jumpHeight > transform.position.y)
            {
                //ySpeed = jumpSpeed;

                anim.SetBool("isGround", false);

                if (UnityEngine.Input.GetKey(KeyCode.RightArrow) && l_run)
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
            else
            {
                isJump = false;
                anim.SetBool("isGround", true);

                //if (r_run) anim.SetBool("r_jump", false);
                //else if (l_run) anim.SetBool("l_jump", false);
            }
        }

        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("r_run", true);
            anim.SetBool("l_run", false);
            r_run = true;
            l_run = false;
            //xSpeed = speed;
        }
        else if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("l_run", true);
            anim.SetBool("r_run", false);
            l_run = true;
            r_run = false;
            //xSpeed = -speed;
        }
        else
        {
            if (r_run)
            {
                anim.SetBool("r_run", false);
                //r_run = false;
                //xSpeed = 0.0f;
            }
            else if (l_run)
            {
                anim.SetBool("l_run", false);
                //l_run = false;
                //xSpeed = 0.0f;
            }
        }

        //if (UnityEngine.Input.GetKey(KeyCode.E))
        //{
        //    girl.SetBool("isHappy", true);
        //}

        //if (UnityEngine.Input.GetKey(KeyCode.R))
        //{
        //    anim.SetBool("kanjo", true);
        //}
        //else
        //{
        //    anim.SetBool("kanjo", false);
        //}

        //rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
