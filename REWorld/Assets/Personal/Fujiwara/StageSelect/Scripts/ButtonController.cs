using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ButtonController : Singleton<ButtonController>
{
    // pageの取得
    [SerializeField] GameObject[] pages;

    // ボタンの取得
    [SerializeField] Image[] buttons;

    // スクリプトの取得
    [SerializeField] FadeController fade;

    // 色の設定
    Color basicColor = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
    Color afterColor = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 100.0f / 255.0f);

    int nowPage = 0;

    // Start is called before the first frame update
    void Start()
    {
        AllInit();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (UnityEngine.Input.GetKeyUp(KeyCode.A) || UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (nowPage != 0) BackPage();
        }
        else if (UnityEngine.Input.GetKeyUp(KeyCode.D) || UnityEngine.Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (nowPage != 1) NextPage();
        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.Return))
        {
            SceneMove();
            //UI_MenuButton.Instance.SubmitMenu();
        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScreen");
        }
        */
    }

    // 初期化
    void AllInit()
    {
        for(int i = 0; i < pages.Length; i++)
        {
            if (i != 0) pages[i].SetActive(false);
            else pages[i].SetActive(true);
        }

        buttons[0].color = afterColor;
        buttons[1].color = basicColor;
    }

    public void SceneMove()
    {
        switch (nowPage)
        {
            case 0:
                fade.StartFade("Stage1");
                break;
            case 1:
                fade.StartFade("Stage2");
                break;
        }
    }

    // indexは0~3
    public void PageChange(int index)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (i == index) pages[i].SetActive(true);
            else pages[i].SetActive(false);
        }

        if (index == 0)
        {
            buttons[0].color = afterColor;
        }
        else if (index == (pages.Length-1))
        {
            buttons[1].color = afterColor;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != index)
            {
                buttons[i].color = basicColor;
            }
        }
    }

    public void NextPage()
    {
        if (nowPage == 1) return;
        nowPage++;       
        PageChange(nowPage);
    }

    public void BackPage()
    {
        if (nowPage == 0) return;
        nowPage--;
        PageChange(nowPage);
    }
}
