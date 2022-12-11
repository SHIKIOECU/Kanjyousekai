using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    [SerializeField]
    FlagData _coin;

    [SerializeField]
    GameObject _coinUI;

    [SerializeField]
    FlagData _ice;

    [SerializeField]
    GameObject _iceUI;

    private bool isCoinGet;
    private bool isIceGet;

    // Start is called before the first frame update
    void Start()
    {
        _coinUI.SetActive(false);
        _iceUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCoinGet = _coin.IsOn;
        isIceGet = _ice.IsOn;

        if(isCoinGet == true)
        {
            _coinUI.SetActive(true);
            _iceUI.SetActive(false);
        }
        else if(isIceGet == true)
        {
            _coinUI.SetActive(false);
            _iceUI.SetActive(true);
        }
        else
        {
            _coinUI.SetActive(false);
            _iceUI.SetActive(false);
        }
    }
}
