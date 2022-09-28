using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public Rigidbody2D Rb2D;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ICE");
        if (collision.CompareTag("Ground"))
        {
            Rb2D.velocity = new Vector2(0, 0);
            Rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
