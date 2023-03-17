using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New ItemData", menuName = "ScriptableObject/Item/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }
    [SerializeField]
    private bool _isOn = false;
    public bool IsOn { get { return _isOn; } }
    [SerializeField]
    private Sprite _sprite;
    public Sprite Sprite { get { return _sprite; } }

    public int Count;

    private void Awake()
    {
        InitItem();
    }

    public void InitItem()
    {
        _isOn = false;
        Count= 0;
    }

    public void SetItemStatus(bool value = true)
    {
        _isOn = value;
        if (value)
        {
            ItemManager.Instance.AddItem(this);
            Count++;
        }
        else
        {
            ItemManager.Instance.RemoveItem(this);
            Count--;
        }

        if(Count>0) _isOn= true;
    }

}
