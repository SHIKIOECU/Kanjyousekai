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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WoodBox"))
        {
            spriteRenderer.sprite = bigIce2;
        }
    }
}
