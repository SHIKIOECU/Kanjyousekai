using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JihankiCollider : MonoBehaviour
{
    [SerializeField] GameObject jihanki;
    BoxCollider2D jihankicollider;

    // Start is called before the first frame update
    void Start()
    {
        jihankicollider = jihanki.GetComponent<BoxCollider2D>();
        jihankicollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundCheck"))
        {
            Debug.Log("自販機のcolliderを有効にしました");
            jihankicollider.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundCheck"))
        {
            Debug.Log("自販機のcolliderを無効にしました");
            jihankicollider.enabled = false;
        }
    }
}
