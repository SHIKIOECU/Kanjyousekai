using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    #region 変数宣言
    [SerializeField]
    private GameObject _player;

    //Playerの動作のスクリプト
    private PlayerMove _playerMove;

    //メニューのアクティブ状態
    private bool _isMenu;

    #endregion

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerMove = _player.GetComponent<PlayerMove>();
        _isMenu = false;
    }

    #region Player
    //Playerの移動
    public void OnMove(InputAction.CallbackContext context)
    {
        _playerMove.move = context.ReadValue<Vector2>();

        if (_playerMove.move.x > 0)
        {
            PlayerAnimator.instance.SetDirection();
        }
        else if (_playerMove.move.x < 0)
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
            _playerMove.rb2D.velocity = new Vector2(0, _playerMove.rb2D.velocity.y);
            PlayerAnimator.instance.SetMove(false);
        }
    }

    //Playerのジャンプ
    public void OnJump(InputAction.CallbackContext context)
    {
        //Spaceが押された時に起動
        if (context.phase == InputActionPhase.Performed && _playerMove.jumpState == false)
        {
            _playerMove.Jump();
            PlayerAnimator.instance.SetJump();
            _playerMove.jumpState = true;
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
    #endregion

    #region UI
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (_isMenu)
            {
                Menu.Instance.MenuCancel();
                UI_MenuButton.Instance.Init();
            }
            else Menu.Instance.MenuScreen();

            _isMenu = !_isMenu;
        }
        
    }

    public void OnMenuSelect(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started&&_isMenu)
        {
            var x = context.ReadValue<Vector2>();
            int value = 0;
            if (x.y > 0) value = 1;
            else if (x.y < 0) value = -1;
            UI_MenuButton.Instance.ChangeSelectButton(value);
        }

    }

    public void OnMenuSubmit(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (_isMenu) UI_MenuButton.Instance.SubmitMenu();

        }

    }
    #endregion

    private void Update()
    {

    }
}