using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    private bool _isWorld=false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("World"))
        {
            _isWorld = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("World")&&_isWorld)
        {
            Interact.instance.nowKansoku.DisappearanceWorld();
            _isWorld = false;
        }

    }

    }