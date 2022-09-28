using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrildAnimmator : MonoBehaviour
{
    private Animator crying = null;

    //public GameObject girl;

    bool getIce = false;

    // Start is called before the first frame update
    void Start()
    {
        crying = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (getIce == true)
        {
            crying.SetBool("isHappy", true);
        }
        else
        {
            crying.SetBool("isHappy", false);
        }

        if (UnityEngine.Input.GetKey(KeyCode.E))
        {
            getIce = true;
        }
    }
}
