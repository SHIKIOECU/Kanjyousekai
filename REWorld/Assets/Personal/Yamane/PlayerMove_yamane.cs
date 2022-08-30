using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_yamane : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.05f;

    [SerializeField]
    private float jump;

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * speed;
        //position.y += Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            position.y += jump;
        }

        transform.position = position;
    }
}
