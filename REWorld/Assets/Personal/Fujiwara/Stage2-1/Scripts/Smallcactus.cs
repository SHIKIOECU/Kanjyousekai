using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smallcactus : MonoBehaviour
{
    [SerializeField] private FlagData smallcactus;

    public bool isGet;

    public void ItemAction()
    {
        smallcactus.SetFlagStatus();
        isGet = true;
        gameObject.SetActive(false);
    }
}
