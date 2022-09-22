using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove_yamane : MonoBehaviour
{
    //[SerializeField]
    //private float speed = 0.05f;

    //[SerializeField]
    //private float jump;

<<<<<<< HEAD
    //private void Update()
    //{
    //    Movement();
    //}

    //public void Movement()
    //{
    //    Vector2 position = transform.position;

    //    position.x += Input.GetAxis("Horizontal") * speed;
    //    //position.y += Input.GetAxis("Vertical");

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        position.y += jump;
    //    }
=======
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Keyboard keyboard = Keyboard.current;

        Vector2 position = transform.position;

        //position.x += Input.GetAxis("Horizontal") * speed;
        //position.y += Input.GetAxis("Vertical");

        //入力した方向へ移動（現在X軸のみ反応）
        rb2D.AddForce(position * speed, ForceMode2D.Impulse);

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            position.y += jump;
        }
>>>>>>> feature/NPC/YamaneKuta

    //    transform.position = position;
    //}
}
