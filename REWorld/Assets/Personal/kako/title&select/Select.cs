using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public string StageSelect = "select";

    public void OnClick()
    {
        SceneManager.LoadScene(StageSelect);
    }
}
