using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObserve : MonoBehaviour
{
    //private GameObject observe;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    observe = this.transform.Find("Observe").gameObject;
    //}

<<<<<<< HEAD
    //// Update is called once per frame
    //void Update()
    //{
    //    //左クリックを受け付ける
    //    if (Input.GetMouseButtonDown(0))
    //        if(observe.activeInHierarchy)
    //        {
    //            observe.SetActive(false);
    //        }
    //        else
    //        {
    //            observe.SetActive(true);
    //        }
    //}
=======
    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;

        // 左クリックをしている
        if (mouse.leftButton.wasPressedThisFrame)
        {
            if (observe.activeInHierarchy)
            {
                observe.SetActive(false);
            }
            else
            {
                observe.SetActive(true);
            }
        }
    }
>>>>>>> feature/NPC/YamaneKuta
}
