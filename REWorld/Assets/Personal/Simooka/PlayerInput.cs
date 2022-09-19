using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //PlayerのRigidbody2D
    private Rigidbody2D rb2D;

    //移動方向
    private Vector2 move;

    [Header("移動速度")]
    [SerializeField]
    private float speed;

    [Header("ジャンプの大きさ")]
    [SerializeField]
    private float jumpPower;

    //ジャンプ状態
    private bool jumpState;

    public InputAction InputAction;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jumpState = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Spaceが押された時に起動
        if (context.phase == InputActionPhase.Performed && jumpState == false)
        {
            rb2D.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            jumpState = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(move * speed * Time.deltaTime);
        rb2D.AddForce(move * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            jumpState = false;
        }
    }
}