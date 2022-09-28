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
        jump = icecle.jumping;

        if (jump == false)
        {
            if (iceclethrow.activeSelf == true)
            {
                animator.SetBool("kansokuTrigger", true);
            }
            if (iceclethrow.activeSelf == false)
            {
                animator.SetBool("kansokuTrigger", false);
            }
        }
        else if (jump == true)
        {
            if (iceclethrow.activeSelf == true)
            {
                animator.SetBool("jumpTrigger", true);
            }
            if (iceclethrow.activeSelf == false)
            {
                animator.SetBool("jumpTrigger", false);
            }
        }

    }
}
