using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : InteractMessage,IItem
{
    [SerializeField] private FlagData _coin;
    [SerializeField] private FlagData _drink;

    #region IItem

    public void ItemAction()
    {
        if (_coin.IsOn)
        {
            _coin.SetFlagStatus(false);
            _drink.SetFlagStatus();
        }
    }
    #endregion
}
