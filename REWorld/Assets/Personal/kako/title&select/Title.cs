using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject CanvasobjT;
    public GameObject CanvasobjF;
    public int MoveNumber = 0;
    public GameObject Cameraobj;

    public void OnClick()
    {
        Vector3 pos = Cameraobj.transform.position;
        pos.y = MoveNumber;
        Cameraobj.transform.position = pos;

        CanvasobjT.SetActive(true);
        CanvasobjF.SetActive(false);
    }
}
