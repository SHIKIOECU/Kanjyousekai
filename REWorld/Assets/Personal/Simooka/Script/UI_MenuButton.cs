using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuButton : Singleton<UI_MenuButton>
{
    private int _nowNum;
    [SerializeField] private Button[] _buttons;
    // Start is called before the first frame update
    void Awake()
    {
        _buttons = transform.GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        _buttons[_nowNum].Select();
        Debug.Log(_buttons[_nowNum].name);
    }

    public void Init()
    {
        _nowNum = 0;
        _buttons[_nowNum].Select();
    }

    public void ChangeSelectButton(int value)
    {
        _nowNum -= value;
        //_nowNum = Mathf.Clamp(_nowNum, 0, _buttons.Length - 1);
        if (_nowNum < 0) _nowNum = 0;
        else if (_nowNum >= _buttons.Length) _nowNum = _buttons.Length - 1;
        Debug.Log(_buttons.Length);
        _buttons[_nowNum].Select();
    }

    public void SubmitMenu()
    {
        _buttons[_nowNum].onClick.Invoke();
    }
}