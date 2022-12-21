using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // pageの取得
    [SerializeField] GameObject[] pages;

    // ボタンの取得
    [SerializeField] Image[] buttons;

    // 色の設定
    Color basicColor = Color.white;
    Color afterColor = new Color(153.0f, 153.0f, 153.0f);

    int nowPage = 0;

    // Start is called before the first frame update
    void Start()
    {
        AllInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 初期化
    void AllInit()
    {
        pages[0].SetActive(true);
        pages[1].SetActive(false);
        pages[2].SetActive(false);
        pages[3].SetActive(false);

        buttons[0].color = afterColor;
        buttons[1].color = basicColor;

        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = true;
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
            buttons[0].color = basicColor;
            buttons[0].GetComponent<Button>().interactable = false;
        }
        else if (index == 3)
        {
            buttons[1].color = basicColor;
            buttons[1].GetComponent<Button>().interactable = false;
        }
        else
        {
            foreach (Image button in buttons)
            {
                button.color = afterColor;
                button.GetComponent<Button>().interactable = true;
            }
        }

        //for (int i = 0; i < buttons.Length; i++)
        //{
        //    if (i == index)
        //    {
        //        buttons[i].color = basicColor;
        //        buttons[i].GetComponent<Button>().interactable = false;
        //    }
        //    else
        //    {
        //        buttons[i].color = afterColor;
        //        buttons[i].GetComponent<Button>().interactable = true;
        //    }
        //}
    }

    public void NextPage()
    {
        nowPage++;
        PageChange(nowPage);
    }

    public void BackPage()
    {
        nowPage--;
        PageChange(nowPage);
    }
}
