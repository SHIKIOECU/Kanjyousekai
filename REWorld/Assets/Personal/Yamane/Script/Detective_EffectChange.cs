using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detective_EffectChange : MonoBehaviour
{
    [Header("変化前")]
    [SerializeField]
    GameObject Before_Detective;

    [Header("変化後")]
    [SerializeField]
    GameObject After_Detective;

    Detective detective;
    private bool IsMove;

    //private bool kanjou;

    [SerializeField]
    GameObject EmotionalWorld;

    // Start is called before the first frame update
    void Start()
    {
        detective = GetComponent<Detective>();

        //kanjou = Interact.instance.isKansoku;
    }

    // Update is called once per frame
    void Update()
    {
        IsMove = detective.moved;

        if (EmotionalWorld.activeSelf == true)
        {
            if (detective.INPCData.Name == "basic" && IsMove == true)
            {
                Before_Detective.SetActive(true);
                After_Detective.SetActive(false);
            }
            else
            {
                Before_Detective.SetActive(false);
                After_Detective.SetActive(true);
            }
        }
        else
        {
            Before_Detective.SetActive(false);
            After_Detective.SetActive(false);
        }
    }
}
