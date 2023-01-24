using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Input_FrontEnd : MonoBehaviour
{
    #region 変数宣言

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
        if (context.phase == InputActionPhase.Started)
        {
            var x = context.ReadValue<Vector2>();
            if (x.x > 0) ButtonController.Instance.NextPage();
            else if (x.x < 0) ButtonController.Instance.BackPage();
        }

    }

    //メニュー決定
    public void OnMenuSubmit(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "TitleScreen":
                    //todo:セレクトシーンへの遷移
                    SceneManager.LoadScene("StageSelect");
                    break;
                case "StageSelect":
                    //セレクトシーン
                    ButtonController.Instance.SceneMove();
                    break;
            }

        }

    }
    #endregion

    private void Update()
    {

    }
}