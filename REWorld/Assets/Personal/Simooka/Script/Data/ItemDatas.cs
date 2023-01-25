using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New ItemData", menuName = "ScriptableObject/Item/ItemData")]
public class ItemDatas : ScriptableObject
{
    [SerializeField]
    private bool _isOn = false;
    public bool IsOn { get { return _isOn; } }
    [SerializeField]
    private Sprite _sprite;
    public Sprite Sprite { get { return _sprite; } }

    public void InitItem()
    {
        _isOn = false;
    }

    public void SetItemStatus(bool value = true)
    {
        _isOn = value;
    }
}
