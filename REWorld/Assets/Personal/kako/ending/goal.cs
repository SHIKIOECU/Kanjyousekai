using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("触れているよーーーーーーーー");
            StartCoroutine(Clearmove());
        }
    }

    private IEnumerator Clearmove()
    {
        yield return new WaitForSeconds(1);

        //SoundManager.instance.stageBGMstop();

        SoundManager.instance.PlaySE(0);

        yield return new WaitForSeconds(4);

        StartTitle.StartSignal = false;
        SceneManager.LoadScene("select");
    }
}
