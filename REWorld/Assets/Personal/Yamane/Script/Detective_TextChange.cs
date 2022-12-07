using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Detective_TextChange : MonoBehaviour
{
    [SerializeField]
    Detective detective;

    [SerializeField]
    private TextMeshProUGUI DetectiveText;

    [Header("アイスが売れる前のセリフ")]
    [SerializeField]
    string BeforeText;

    [Header("アイスが売れた後のセリフ")]
    [SerializeField]
    string AfterText;

    // Start is called before the first frame update
    void Start()
    {
        DetectiveText.text = BeforeText;
    }

    // Update is called once per frame
    void Update()
    {
        if (detective.INPCData.Name == "happy")
        {
            DetectiveText.text = AfterText;
        }
    }
}
