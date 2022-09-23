using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Clearmove());
        }
    }

    private IEnumerator Clearmove()
    {
        yield return new WaitForSeconds(1);

        SoundManager.instance.stageBGMstop();

        SoundManager.instance.PlaySE(0);

        yield return new WaitForSeconds(4);

        StartTitle.StartSignal = false;
        SceneManager.LoadScene("select");
    }
}
