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

    private void Start()
    {
        PM = Player.GetComponent<PlayerMove>();
    }

    //Playerの移動
    public void OnMove(InputAction.CallbackContext context)
    {
        PM.move = context.ReadValue<Vector2>();

        if (PM.move.x > 0)
        {
            PlayerAnimator.instance.SetDirection();
        }
        else if (PM.move.x < 0)
        {
            PlayerAnimator.instance.SetDirection(false);
        }

        //ボタンを押した時
        if (context.phase == InputActionPhase.Started)
        {
            PlayerAnimator.instance.SetMove();
        }

        //ボタンを離した時
        if (context.phase == InputActionPhase.Canceled)
        {
            //X軸の速度を０にする
            PM.rb2D.velocity = new Vector2(0, PM.rb2D.velocity.y);
            PlayerAnimator.instance.SetMove(false);
        }
    }

    //Playerのジャンプ
    public void OnJump(InputAction.CallbackContext context)
    {
        //Spaceが押された時に起動
        if (context.phase == InputActionPhase.Performed && PM.jumpState == false)
        {
            PM.Jump();
            PlayerAnimator.instance.SetJump();
            PM.jumpState = true;
        }
    }

    public void OnGet(InputAction.CallbackContext context)
    {
        //ボタンを押した時
        if (context.phase == InputActionPhase.Started)
        {
            PlayerMove.instance.rb2D.WakeUp();
            Interact.instance.OnGet = true;
        }

        //ボタンを離した時
        if (context.phase == InputActionPhase.Canceled)
        {
            Interact.instance.OnGet = false;

            //取得していない状態にする
            Interact.instance.isGet = false;
        }
    }

    public void OnKansoku(InputAction.CallbackContext context)
    {
        //ボタンを押した時
        if (context.phase == InputActionPhase.Started)
        {
            PlayerMove.instance.rb2D.WakeUp();
            Interact.instance.OnKansoku = true;
        }

        //ボタンを離した時
        if (context.phase == InputActionPhase.Canceled)
        {
            Interact.instance.OnKansoku = false;
            Interact.instance.isKansoku = false;
        }
    }
}