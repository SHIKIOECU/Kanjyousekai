using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    [SerializeField] GameObject fade_img;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFade(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    public IEnumerator FadeOut(string name)
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

        if (name != null) SceneManager.LoadScene(name);
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
