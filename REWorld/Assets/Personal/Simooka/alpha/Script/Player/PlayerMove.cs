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
    private float speed;

    [Header("ジャンプの大きさ")]
    [SerializeField]
    private float jumpPower;

    //ジャンプ状態
    public bool jumpState;

    

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jumpState = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            jumpState = false;
    }

    //private void Move()
    //{
    //    //入力した方向へ移動（現在X軸のみ反応）
    //    rb2D.AddForce(move * speed, ForceMode2D.Impulse);
    //}

    private void Move()
    {
        //入力した方向へ移動（現在X軸のみ反応）
        rb2D.velocity = new Vector2(move.x * speed, rb2D.velocity.y);
    }

    public void Jump()
    {
        //Y軸方向へ移動
        rb2D.velocity = transform.up * jumpPower;
    }
}
