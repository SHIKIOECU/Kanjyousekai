using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_JumpUp_Effect : MonoBehaviour
{
    private bool happy;

    [SerializeField]
    IceClerk iceclerk;

    [SerializeField]
    GameObject ice_JumpUp_Effect;

    // Start is called before the first frame update
    void Start()
    {
        happy = iceclerk.jumping;
    }

    // Update is called once per frame
    void Update()
    {
        if(happy == true)
        {
            ice_JumpUp_Effect.SetActive(true);
        }
        else
        {
            ice_JumpUp_Effect.SetActive(false);
        }
    }
}
