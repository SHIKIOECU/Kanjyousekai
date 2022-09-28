using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrildAnimmator : MonoBehaviour
{
    private Animator crying = null;

    [SerializeField]
    private Girl _girl;

    // Start is called before the first frame update
    void Start()
    {
        crying = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_girl.getIce == true)
        {
            crying.SetBool("isHappy", true);
        }
        else
        {
            crying.SetBool("isHappy", false);
        }
    }
}
