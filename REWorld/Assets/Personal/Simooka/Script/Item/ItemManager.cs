using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [SerializeField] private FlagList _itemList; //アイテムリスト
    [Header("アイテムデータ")]
    [SerializeField] private int _size; //アイテムデータの数
    [SerializeField] private ItemData[] _items; //アイテムデータ

    //[SerializeField]private ItemData[] _items; //所持数

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _items = new ItemData[_size];
        _itemList.InitFlags();

        //InitItem();
    }

    private void InitItem()
    {
        //for (int i = 0; i < _itemList.Flags.Count; i++)
        //{
        //    var data = new ItemData();
        //    data.Name = _itemList.Flags[i].name;
        //    //data.Count = 0;
        //    _items.Add(data);
        //}
    }

    public void AddItemCount(FlagData itemFlag,int count)
    {
        //for(int i = 0; i < _items.Count; i++)
        //{
        //    if (_items[i].Name == itemFlag.name)
        //    {
        //        var item = _items[i];
        //        item.Count += count;
        //        if (item.Count < 0) break;
        //        _items[i] = item;
        //        break;
        //    }
        //}
    }

    /// <summary>
    /// itemFlagの名前と同じアイテムデータを追加する
    /// </summary>
    /// <param name="itemFlag"></param>
    public void AddItem(FlagData itemFlag)
    {
        for(int i = 0; i < _items.Length; i++)
        {
            if (_items[i].Name==null)
            {
                _items[i].Name = itemFlag.name;
                break;
            }
        }
    }

    /// <summary>
    /// itemFlagの名前と同じアイテムデータを除去する
    /// </summary>
    /// <param name="itemFlag"></param>
    public void RemoveItem(FlagData itemFlag)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i].Name == itemFlag.name)
            {
                _items[i].Name = null;
                break;
            }
        }
    }
}

[System.Serializable]
public struct ItemData
{
    public string Name;
    //public int Count;
    public Sprite Sprite;
}
