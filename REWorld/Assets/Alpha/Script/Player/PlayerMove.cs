using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    //PlayerのRigidbody2D
    public Rigidbody2D rb2D;

    //移動方向
    public Vector2 move;

    [Header("移動速度")]
    [SerializeField]
    private float _speed;

    [Header("ジャンプの大きさ")]
    public float basicJumpPower;
    public float jumpPower;

    //ジャンプ状態
    public bool jumpState;

    ////接地判定
    //[SerializeField]
    //private GameObject _checkGround;

    public Animator playerAnimator;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetBool("isGround", true);
        jumpState = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(CheckGround());
        //jumpState = CheckGround();
        playerAnimator.SetBool("isGround", true);
        playerAnimator.SetBool("r_jump", false);
        playerAnimator.SetBool("l_jump", false);
    }

    private void Move()
    {
        //入力した方向へ移動（現在X軸のみ反応）
        rb2D.velocity = new Vector2(move.x * _speed, rb2D.velocity.y);
        if (move.x > 0)
        {
            playerAnimator.SetBool("l_run", false);
            playerAnimator.SetBool("r_run", true);
        }
        else if (move.x < 0)
        {
            playerAnimator.SetBool("r_run", false);
            playerAnimator.SetBool("l_run", true);
        }
        else
        {
            playerAnimator.SetBool("l_run", false);
            playerAnimator.SetBool("r_run", false);
        }
    }

    public void Jump()
    {
        //Debug.Log(hit.collider.gameObject.name);
        //Y軸方向へ移動
        rb2D.velocity = transform.up * jumpPower;
        playerAnimator.SetBool("isGround", false);
        if (move.x > 0)
        {
            playerAnimator.SetBool("l_jump", false);
            playerAnimator.SetBool("r_jump", true);
        }
        else if (move.x < 0)
        {
            playerAnimator.SetBool("r_jump", false);
            playerAnimator.SetBool("l_jump", true);
        }
    }

    //bool CheckGround()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(_checkGround.transform.position, Vector2.down, 1f);
    //    if (hit.collider.gameObject.name == "floor") return true;
    //    else return false;
    //}
}
