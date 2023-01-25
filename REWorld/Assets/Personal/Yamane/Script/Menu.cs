using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : Singleton<Menu>
{
    [SerializeField]
    GameObject _menuScreenButton;

    [SerializeField]
    GameObject _menuScreen;

    [Header("ステージセレクトシーン名")]
    [SerializeField]
    string _stageSelectName;

    [Header("タイトルシーン名")]
    [SerializeField]
    string _titleName;

    private void Awake()
    {
        _menuScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        _menuScreen.SetActive(false);
        _menuScreenButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuScreen()
    {
        _menuScreen.SetActive(true);
        _menuScreenButton.SetActive(false);
    }

    public void MenuCancel()
    {
        _menuScreen.SetActive(false);
        _menuScreenButton.SetActive(true);
    }

    public void MenuRetry()
    {
        _menuScreen.SetActive(false);
        _menuScreenButton.SetActive(true);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuStageSelect()
    {
        _menuScreen.SetActive(false);
        _menuScreenButton.SetActive(true);

        SceneManager.LoadScene(_stageSelectName);
    }

    public void MenuTitle()
    {
        _menuScreen.SetActive(false);
        _menuScreenButton.SetActive(true);

        SceneManager.LoadScene(_titleName);
    }
}
