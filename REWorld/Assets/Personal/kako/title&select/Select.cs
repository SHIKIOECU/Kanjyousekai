using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public string StageName;

    public void OnClick()
    {
        StartCoroutine(SelectMove());
    }

    private IEnumerator SelectMove()
    { 
        SoundManagerA.Instance.PlaySE(SoundManagerA.SE_List.Select_Stage);

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(StageName);
    }

}
