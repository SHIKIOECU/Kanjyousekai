using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject CanvasobjT;
    public GameObject CanvasobjF;

    public void OnClick()
    {

        CanvasobjT.SetActive(true);
        CanvasobjF.SetActive(false);
    }
}
