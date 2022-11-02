using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigIceAnime : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite bigIce2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            spriteRenderer.sprite = bigIce2;
        }
    }
}
