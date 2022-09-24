using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTitle : MonoBehaviour
{
    public static bool StartSignal = true;

    public GameObject CanvasobjT;
    public GameObject CanvasobjS;

    private void Start()
    {
        if (StartSignal)
        {
            CanvasobjT.SetActive(true);
            CanvasobjS.SetActive(false);
        }
        else
        {
            CanvasobjT.SetActive(false);
            CanvasobjS.SetActive(true);
        }
    }
}
