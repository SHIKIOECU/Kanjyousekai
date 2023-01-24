using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("遷移先のシーン名"), SerializeField] private string _toSceneName;

    [SerializeField]
    GameObject StageClearImage;

    [Header("タイトルに戻るまでの時間")]
    [SerializeField]
    float backTitleTime;


    // Start is called before the first frame update
    void Start()
    {
        StageClearImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("ゴールに触れた");
            StageClearImage.SetActive(true);
            SoundManagerA.Instance.stageBGMstop();
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(backTitleTime);
        SceneManager.LoadScene(_toSceneName);
    }
}
