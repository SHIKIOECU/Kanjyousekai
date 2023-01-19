using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
            int value = 0;
            if (x.y > 0) value = 1;
            else if (x.y < 0) value = -1;
            UI_MenuButton.Instance.ChangeSelectButton(value);
        }

    }

    //メニュー決定
    public void OnMenuSubmit(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            UI_MenuButton.Instance.SubmitMenu();

        }

    }
    #endregion

    private void Update()
    {

    }
}