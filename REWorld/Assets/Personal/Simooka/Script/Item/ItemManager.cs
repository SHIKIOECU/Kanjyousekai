using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] private FlagList _itemList; //アイテムリスト
    [Header("アイテムデータ")]
    //[SerializeField] private int _itemSize; //アイテムデータの数
    //[SerializeField] private ItemData[] _items; //アイテムデータ

    [SerializeField] private Image _itemImage;
    [SerializeField] private float _imgRange;
    [SerializeField] private int _size;
    [SerializeField] private Image[] _images;


    [SerializeField] private FlagData _test;


    //[SerializeField]private ItemData[] _items; //所持数

    // Start is called before the first frame update
    void Start()
    {
        //_items = new ItemData[_itemSize];
        _images = new Image[_size];

        for(int i = 0; i < _size; i++)
        {
            _images[i]=Instantiate(_itemImage,_itemImage.transform.parent);
            _images[i].transform.position += new Vector3(_imgRange*i, 0, 0);
        }

        AddItem(_test);
        //_itemList.InitFlags();

        //InitItem();
    }

    private void Update()
    {
        
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

    /// <summary>
    /// itemFlagの名前と同じアイテムデータを追加する
    /// </summary>
    /// <param name="itemFlag"></param>
    public void AddItem(FlagData itemFlag)
    {
        for(int i = 0; i < _images.Length; i++)
        {
            if (_images[i].GetComponentInChildren<Image>().sprite==null)
            {
                _images[i].GetComponentInChildren<Image>().gameObject.name = itemFlag.name;
                //_images[i].GetComponentInChildren<Image>().sprite= itemFlag.name;
                return;
            }
        }
    }

    /// <summary>
    /// itemFlagの名前と同じアイテムデータを除去する
    /// </summary>
    /// <param name="itemFlag"></param>
    public void RemoveItem(FlagData itemFlag)
    {
        for (int i = 0; i < _images.Length; i++)
        {
            if (_images[i].GetComponentInChildren<Image>().sprite != null)
            {
                _images[i].GetComponentInChildren<Image>().sprite = null;
                return;
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
