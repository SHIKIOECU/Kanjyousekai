using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";    // tilemapのground用のtag
    private string woodboxTag = "WoodBox";  // tilemapのwoodbox用のtag
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    public bool IsGround()
    {
        // 着地した時と地面と接している時
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        // 地面から離れた時
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == woodboxTag)
        {
            isGroundEnter = true;
        }

        //if (collision.tag == groundTag)
        //{
        //    Debug.Log("Groundに触れています");
        //}
        //else if (collision.tag == woodboxTag)
        //{
        //    Debug.Log("WoodBoxに触れています");
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == woodboxTag)
        {
            isGroundStay = true;
        }

        //if (collision.tag == groundTag)
        //{
        //    Debug.Log("Groundに触れています");
        //}
        //else if (collision.tag == woodboxTag)
        //{
        //    Debug.Log("WoodBoxに触れています");
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == woodboxTag)
        {
            isGroundExit = true;
        }

        //if (collision.tag == groundTag)
        //{
        //    Debug.Log("Groundに触れています");
        //}
        //else if (collision.tag == woodboxTag)
        //{
        //    Debug.Log("WoodBoxに触れています");
        //}
    }
}
