using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    // チェックマークの取得
    [SerializeField] GameObject checkmark;

    // フラグの取得
    [SerializeField] FlagData flag;

    // Start is called before the first frame update
    void Start()
    {
        if (flag.IsOn) checkmark.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
