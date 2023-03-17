using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : Singleton<ItemManager>
{
    //[SerializeField] private FlagList _itemList; //アイテムリスト
    [Header("アイテムデータ")]
    //[SerializeField] private int _itemSize; //アイテムデータの数
    [SerializeField] private List<ItemData> _items = new List<ItemData>(); //アイテムデータ

    [SerializeField] private Image _itemImage;
    [SerializeField] private Transform _itemsTransform;
    [SerializeField] private int _size;
    [SerializeField] private List<Image> _images=new List<Image>();



    public override void Awake()
    {
        base.Awake();
        for (int x = 0; x < _items.Count; x++)
        {
            _items[x].InitItem();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _size; i++)
        {
            var I = Instantiate(_itemImage, _itemsTransform);
            I.rectTransform.anchoredPosition += new Vector2(_itemImage.rectTransform.sizeDelta.x*2 * i, 0);
            _images.Add(I);
        }
    }

    private void Update()
    {

    }

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
