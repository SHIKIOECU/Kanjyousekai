using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Input_FrontEnd : MonoBehaviour
{
    #region 変数宣言
    [Tooltip("タイトルシーンのみ必要"), SerializeField] TitleManager _titleManager;
    #endregion

    private void Start()
    {

    }

    #region UI

    //メニュー
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
                Menu.Instance.MenuCancel();
                UI_MenuButton.Instance.Init();
            Menu.Instance.MenuScreen();

        }
        
    }

    //メニュー選択
    public void OnMenuSelect(InputAction.CallbackContext context)
    {
        Debug.Log("select");
        if (context.phase == InputActionPhase.Started)
        {
            var x = context.ReadValue<Vector2>();
            if (x.x > 0) ButtonController.Instance.NextPage();
            else if (x.x < 0) ButtonController.Instance.BackPage();
        }

    }

    //ステージセレクトからタイトルへ
    public void OnSelectToStage(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            ButtonController.Instance.SceneMove();
        }

    }

    //タイトルからステージセレクトへ
    public void OnTitleToSelect(InputAction.CallbackContext context)
    {
        Debug.Log("push");
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("start");
            _titleManager.StartFade();
        }
    }

    public void OnSelectToTitle(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

    public void OnQuitGame(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _titleManager.QuitGame();
        }
    }

    #endregion

    private void Update()
    {

    }
}