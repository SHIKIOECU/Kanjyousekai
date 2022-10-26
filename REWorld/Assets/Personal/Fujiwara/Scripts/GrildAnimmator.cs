using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrildAnimmator : MonoBehaviour
{
    private Animator crying = null;

    [SerializeField]
    private Girl _girl;

    //string trigger = "";

    // Start is called before the first frame update
    void Start()
    {
        crying = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_girl._getIce == true)
        {
            crying.SetBool("isHappy", true);
        }
        else
        {
            crying.SetBool("isHappy", false);
        }

        //if (UnityEngine.Input.GetKey(KeyCode.E))
        //{
        //    trigger = "isHappy";
        //    crying.SetBool(trigger, true);
        //}
    }
}
