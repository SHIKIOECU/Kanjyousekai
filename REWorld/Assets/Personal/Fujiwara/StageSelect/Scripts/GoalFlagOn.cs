using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlagOn : MonoBehaviour
{
    [SerializeField] FlagData challengeflag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            challengeflag.SetFlagStatus();
        }
    }
}
