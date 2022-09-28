using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAnime : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    GameObject iceclethrow;

    private bool kansoku;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
}
