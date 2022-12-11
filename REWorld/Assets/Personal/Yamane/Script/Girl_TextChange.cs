using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Girl_TextChange : MonoBehaviour
{
    [SerializeField]
    Girl girl;

    [SerializeField]
    private TextMeshProUGUI GirlText;

    [Header("アイスをもらう前のセリフ")]
    [SerializeField]
    string BeforeText;

    [Header("アイスをもらった後のセリフ")]
    [SerializeField]
    string AfterText;

    // Start is called before the first frame update
    void Start()
    {
        GirlText.text = BeforeText;
    }

    // Update is called once per frame
    void Update()
    {
        if (girl.INPCData.Name == "happy")
        {
            GirlText.text = AfterText;
        }
    }
}
