using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    /* オブジェクトの取得 */
    [SerializeField] GameObject player;     // プレイヤー
    [SerializeField] GameObject satori;     // サトリ
    [SerializeField] GameObject savePoint;  // セーブポイント
    [SerializeField] GameObject fadeout_image; // フェードアウト

    Color color;

    [SerializeField] float fadeoutSpeed;

    bool isGameOver;
    bool isBig, isSmall;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isBig = true;

        color = fadeout_image.GetComponent<Image>().color;
        color.a = 0.0f;
        fadeout_image.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeOut()
    {
        Image fadeout = fadeout_image.GetComponent<Image>();

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

        // プレイヤーをセーブポイントに移動させる
        player.transform.position = savePoint.transform.position;
        satori.transform.position = new Vector3(savePoint.transform.position.x - 1, savePoint.transform.position.y, savePoint.transform.position.z);

        //yield return new WaitForSeconds(1.0f);

        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        Image fadeout = fadeout_image.GetComponent<Image>();

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
    }
}
