using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject fade_img;

    [SerializeField] FlagData[] challengesData;

    static int n = 0;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);

        if (n == 0)
        {
            DontDestroyOnLoad(gameObject);
            foreach (FlagData flag in challengesData)
            {
                flag.InitFlag();
            }
            n++;
        }
        Debug.Log(n);
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyUp(KeyCode.Return))
        {
            StartFade();
        }
        else if (UnityEngine.Input.GetKeyUp(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

    public void StartFade()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Image fadeout = fade_img.GetComponent<Image>();

        fadeout.color = new Color((0.0f / 255.0f), (0.0f / 255.0f), (0.0f / 0.0f), (0.0f / 255.0f));

        float fade_time = 0.5f;

        int loop_count = 50;

        float wait_time = fade_time / loop_count;

        float alpha_interval = 255.0f / loop_count;

        for (float alpha = 0.0f; alpha <= 255.0f; alpha += alpha_interval)
        {
            yield return new WaitForSeconds(wait_time);

            Color new_color = fadeout.color;
            new_color.a = alpha / 255.0f;
            fadeout.color = new_color;
        }

        StartCoroutine(FadeIn());

        SceneManager.LoadScene("StageSelect");
    }

    public IEnumerator FadeIn()
    {
        Image fadeout = fade_img.GetComponent<Image>();

        float fade_time = 0.5f;

        int loop_count = 50;

        float wait_time = fade_time / loop_count;

        float alpha_interval = 255.0f / loop_count;

        for (float alpha = 255.0f; alpha >= 0.0f; alpha -= alpha_interval)
        {
            yield return new WaitForSeconds(wait_time);

            Color new_color = fadeout.color;
            new_color.a = alpha / 255.0f;
            fadeout.color = new_color;
        }

        Destroy(gameObject);
    }
}
