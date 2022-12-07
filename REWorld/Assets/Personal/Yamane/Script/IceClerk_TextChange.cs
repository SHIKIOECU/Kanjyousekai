using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NPC;

public class IceClerk_TextChange : MonoBehaviour
{
    [SerializeField]
    IceClerk iceClerk;

    [SerializeField]
    private TextMeshProUGUI IceClerkText;

    [Header("アイスが売れる前のセリフ")]
    [SerializeField]
    string BeforeText;

    [Header("アイスが売れた後のセリフ")]
    [SerializeField]
    string AfterText;

    // Start is called before the first frame update
    void Start()
    {
        IceClerkText.text = BeforeText;
    }

    // Update is called once per frame
    void Update()
    {
        if(iceClerk.INPCData.Name == "happy")
        {
            IceClerkText.text = AfterText;
        }
    }
}
