using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necklace : MonoBehaviour, IItem
{
    [SerializeField] private FlagData necklace;

    public bool isGet;

    public void ItemAction()
    {
        necklace.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
