using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            PlayerMove.Instance.jumpState = false;
            PlayerAnimator.instance.SetJump(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground"
            && GameState.Instance.NowState==GameState.State.Play)
        {
            PlayerMove.Instance.jumpState = true;
            PlayerAnimator.instance.SetJump();
        }
    }
}
