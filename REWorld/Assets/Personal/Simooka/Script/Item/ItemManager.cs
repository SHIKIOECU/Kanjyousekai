using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : Singleton<ItemManager>
{
    //[SerializeField] private FlagList _itemList; //アイテムリスト
    [Header("アイテムデータ")]
/*    //[SerializeField] private int _itemSize; //アイテムデータの数
    [SerializeField] private ItemData[] _items; //アイテムデータ*/

    [SerializeField] private Image _itemImage;
    [SerializeField] private Transform _itemsTransform;
    [SerializeField] private float _imgRange;
    [SerializeField] private int _size;
    [SerializeField] private List<Image> _images=new List<Image>();


    [SerializeField] private ItemData _test;


    // Start is called before the first frame update
    void Start()
    {
        //_items = new ItemData[_itemSize];
        //_images = new Image[_size];

        for(int i = 0; i < _size; i++)
        {
            var I = Instantiate(_itemImage, _itemsTransform);
            I.transform.position += new Vector3(_imgRange * i, 0, 0);
            _images.Add(I);
        }

        //_itemList.InitFlags();

        //InitItem();
    }

    private void Update()
    {

    }

/*    private void InitItem()
    {
        for (int i = 0; i < _itemList.Flags.Count; i++)
        {
            var data = new ItemData();
            data.Name = _itemList.Flags[i].name;
            data.Count = 0;
            //_items[i].Add(data);
        }
    }*/

    /// <summary>
    /// itemFlagの名前と同じアイテムデータを追加する
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(ItemData item)
    {
        for(int i = 0; i < _images.Count; i++)
        {
            if (_images[i].transform.GetChild(0).GetComponent<Image>().sprite==null)
            {
                _images[i].GetComponentInChildren<Image>().gameObject.name = item.Name;
                //_images[i].transform.GetChild(0).GetComponent<Image>().sprite= itemFlag.name;
                //_items[i].Name = itemFlag.name;
                _images[i].transform.GetChild(0).GetComponent<Image>().sprite = item.Sprite;
                _images[i].transform.GetChild(0).GetComponent<Image>().color=new Color(1,1,1,1);

                return;
            }
        }
    }

    /// <summary>
    /// itemFlagの名前と同じアイテムデータを除去する
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(ItemData item)
    {
        for (int i = 0; i < _images.Count; i++)
        {
            if (_images[i].transform.GetChild(0).GetComponent<Image>().sprite != null
                && _images[i].GetComponentInChildren<Image>().gameObject.name == item.Name)
            {
                _images[i].GetComponentInChildren<Image>().gameObject.name = "NONE";
                _images[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                _images[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);

                return;
            }
        }
    }
}
