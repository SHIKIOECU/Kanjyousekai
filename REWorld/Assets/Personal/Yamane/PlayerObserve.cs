using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObserve : MonoBehaviour
{
    private GameObject observe;

    // Start is called before the first frame update
    void Start()
    {
        observe = this.transform.Find("Observe").gameObject;
    }

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
}
