using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : InteractMessage,IItem
{
    [SerializeField] private ItemData _coin;
    [SerializeField] private ItemData _drink;
    [SerializeField] private ItemData _ice;

    #region IItem

    public void ItemAction()
    {
        if (_coin.IsOn&&_ice.IsOn)
        {
            _coin.SetItemStatus(false);
            _drink.SetItemStatus();
        }
    }
    #endregion
}
