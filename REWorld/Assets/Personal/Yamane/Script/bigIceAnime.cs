using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigIceAnime : MonoBehaviour
{
    Rigidbody2D Rb2D;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite bigIce2;

    public float timeToMelt;
    [SerializeField] float speed;
    public float fallSpeed;
    public float countDown;

    Vector3 targetPos = new Vector3(6.3f, -3.6f, 0.16f);

    public bool isMelt = false;

    // Start is called before the first frame update
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        isMelt = false;
        countDown = timeToMelt;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMelt) IceMelt();
    }

    void IceMelt()
    {
        fallSpeed += speed * Time.deltaTime;

        if (transform.position == targetPos)
        {
            isMelt = false;
            fallSpeed = 0.0f;
            countDown = timeToMelt;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, fallSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            spriteRenderer.sprite = bigIce2;
            Rb2D.velocity = new Vector2(0, 0);

            // ポジションの取得
            //targetPos = new Vector3(transform.position.x, transform.position.y - 1.1f, transform.position.z);

            //isMelt = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            countDown -= Time.deltaTime;

            if (countDown <= 0)
            {
                isMelt = true;
                countDown = 0;
            }
        }
    }
}
