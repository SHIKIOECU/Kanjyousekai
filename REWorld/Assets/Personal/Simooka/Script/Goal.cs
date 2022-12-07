using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("遷移先のシーン名"), SerializeField] private string _toSceneName;

    [SerializeField]
    GameObject StageClearImage;

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
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_toSceneName);
    }
}
