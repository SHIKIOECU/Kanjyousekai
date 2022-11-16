using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject _menuScreenButton;

    [SerializeField]
    GameObject _menuScreen;

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

        SceneManager.LoadScene("select_test");
    }

    public void MenuTitle()
    {
        _menuScreen.SetActive(false);
        _menuScreenButton.SetActive(true);

        SceneManager.LoadScene("Title");
    }
}
