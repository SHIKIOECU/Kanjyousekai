using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAnime : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    GameObject iceclethrow;

    [SerializeField]
    IceClerk icecle;

    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = icecle._jumping;

        switch(jump)
        {
            case true:
                switch(iceclethrow.activeSelf)
                {
                    case true:
                        animator.SetBool("jumpTrigger", true);
                        break;

                    case false:
                        animator.SetBool("jumpTrigger", false);
                        break;
                }
                break;

            case false:
                switch (iceclethrow.activeSelf)
                {
                    case true:
                        animator.SetBool("throwTrigger", true);
                        break;

                    case false:
                        animator.SetBool("throwTrigger", false);
                        break;
                }
                break;
        }
    }
}
