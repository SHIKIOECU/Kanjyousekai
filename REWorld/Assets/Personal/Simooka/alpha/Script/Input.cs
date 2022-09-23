using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    //Playerの動作のスクリプト
    private PlayerMove PM;

    private Interact interact;

    private void Start()
    {
        PM = Player.GetComponent<PlayerMove>();
        interact = Player.GetComponent<Interact>();
    }

    //Playerの移動
    public void OnMove(InputAction.CallbackContext context)
    {
        PM.move = context.ReadValue<Vector2>();
        //ボタンを離した時
        if (context.phase == InputActionPhase.Canceled)
        {
            //X軸の速度を０にする
            PM.rb2D.velocity = new Vector2(0, PM.rb2D.velocity.y);
        }
    }

    //Playerのジャンプ
    public void OnJump(InputAction.CallbackContext context)
    {
        //Spaceが押された時に起動
        if (context.phase == InputActionPhase.Performed && PM.jumpState == false)
        {
            PM.Jump();
            PM.jumpState = true;
        }
    }

    public void OnGet(InputAction.CallbackContext context)
    {
        //ボタンを押した時
        if (context.phase == InputActionPhase.Started)
        {
            interact.OnGet = true;
        }

        //ボタンを離した時
        if (context.phase == InputActionPhase.Canceled)
        {
            interact.OnGet = false;

            //取得していない状態にする
            interact.isGet = false;
        }
    }

    public void OnKansoku(InputAction.CallbackContext context)
    {
        //ボタンを押した時
        if (context.phase == InputActionPhase.Started)
        {
            interact.OnKansoku = true;
        }

        //ボタンを離した時
        if (context.phase == InputActionPhase.Canceled)
        {
            interact.OnKansoku = false;
        }
    }
}