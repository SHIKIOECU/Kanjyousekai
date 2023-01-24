using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Input_HUD : MonoBehaviour
{
    #region 変数宣言
    [SerializeField]
    private GameObject _player;

    //Playerの動作のスクリプト
    private PlayerMove _playerMove;

    #endregion

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerMove = _player.GetComponent<PlayerMove>();
    }

    #region Play
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

                PlayerAnimator.instance.SetMove();

            //ボタンを離した時
            if (context.phase == InputActionPhase.Canceled)
            {

                PlayerAnimator.instance.SetMove(false);
            }
    }

    //Playerのジャンプ
    public void OnJump(InputAction.CallbackContext context)
    {
        if (GameState.Instance.NowState == GameState.State.Play)
        {
            //Spaceが押された時に起動
            if (context.phase == InputActionPhase.Performed && _playerMove.jumpState == false)
            {
                _playerMove.Jump();
                PlayerAnimator.instance.SetJump();
                _playerMove.jumpState = true;
            }
        }
    }

    //プレイヤーのアイテム取得
    public void OnGet(InputAction.CallbackContext context)
    {
        if (GameState.Instance.NowState == GameState.State.Play)
        {
            //ボタンを押した時
            if (context.phase == InputActionPhase.Started)
            {
                PlayerMove.Instance.rb2D.WakeUp();
                Interact.Instance.OnGet = true;
            }

            //ボタンを離した時
            if (context.phase == InputActionPhase.Canceled)
            {
                Interact.Instance.OnGet = false;

                //取得していない状態にする
                Interact.Instance.isGet = false;
            }
        }
    }

    //プレイヤーの観測
    public void OnKansoku(InputAction.CallbackContext context)
    {
        if (GameState.Instance.NowState == GameState.State.Play)
        {
            //ボタンを押した時
            if (context.phase == InputActionPhase.Started)
            {
                PlayerMove.Instance.rb2D.WakeUp();
                Interact.Instance.OnKansoku = true;
            }

            //ボタンを離した時
            if (context.phase == InputActionPhase.Canceled)
            {
                Interact.Instance.OnKansoku = false;
                Interact.Instance.isKansoku = false;
            }
        }
    }

    //メニュー
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (GameState.Instance.NowState == GameState.State.Play
            ||GameState.Instance.NowState==GameState.State.Pause)
        {
            if (context.phase == InputActionPhase.Started)
            {
                switch (GameState.Instance.NowState)
                {
                    case GameState.State.Play:
                        _playerMove.rb2D.simulated = false;
                        PlayerAnimator.instance.SetMove(false);
                        _playerMove.move = Vector2.zero;
                        //メニューを出現させる
                        Menu.Instance.MenuScreen();
                        GameState.Instance.ChangeState(GameState.State.Pause);
                        break;
                    case GameState.State.Pause:
                        Menu.Instance.MenuCancel();
                        UI_MenuButton.Instance.Init();
                        _playerMove.rb2D.simulated = true;
                        GameState.Instance.ChangeState(GameState.State.Play);
                        break;
                }
            }
        }
        
    }

    //メニュー選択
    public void OnMenuSelect(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started
            && GameState.Instance.NowState==GameState.State.Pause)
        {
            var x = context.ReadValue<Vector2>();
            int value = 0;
            if (x.y > 0) value = 1;
            else if (x.y < 0) value = -1;
            UI_MenuButton.Instance.ChangeSelectButton(value);
        }

    }

    //メニュー決定
    public void OnMenuSubmit(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started
            && GameState.Instance.NowState==GameState.State.Pause)
        {
            UI_MenuButton.Instance.SubmitMenu();
            GameState.Instance.NowState = GameState.State.Play;
        }

    }
    #endregion

    private void Update()
    {

    }
}