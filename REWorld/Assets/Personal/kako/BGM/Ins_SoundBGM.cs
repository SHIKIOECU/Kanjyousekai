using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins_SoundBGM : MonoBehaviour
{

    public int BGMnumber = 0;

    private void Start()
    {
        StartCoroutine(StartBGM());
    }

    private IEnumerator StartBGM()
    {
        yield return new WaitForSeconds(1);

        SoundManager.instance.PlayBGM(BGMnumber);
    }
}
