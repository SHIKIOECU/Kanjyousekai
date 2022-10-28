using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("World")&& Interact.instance.nowKansoku!=null)
        {
            Interact.instance.nowKansoku.DisappearanceWorld();
        }

    }
}
