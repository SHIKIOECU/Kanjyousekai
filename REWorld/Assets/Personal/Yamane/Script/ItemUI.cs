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

    [SerializeField]
    private List<string> ItemList;

    // Start is called before the first frame update
    void Start()
    {
        _coinUI.SetActive(false);
        _iceUI.SetActive(false);

        isCoinGet = _coin.IsOn;
        isIceGet = _ice.IsOn;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCoinGet == true)
        {
            _coinUI.SetActive(true);
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
