using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReWorld : MonoBehaviour
{
    private GameObject thisObject;

    // Start is called before the first frame update
    void Start()
    {
        //thisObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Observe"))
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
            Debug.Log("Stay");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Observe"))
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }
            Debug.Log("Exit");
        }
    }
}
