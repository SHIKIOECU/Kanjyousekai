using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour, IItem
{
    [SerializeField] private FlagData banana;

    public bool isGet;

    public void ItemAction()
    {
        banana.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
