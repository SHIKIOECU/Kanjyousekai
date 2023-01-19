using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReWorldFade : MonoBehaviour
{
    [Header("カンジョウ世界のイメージ")]
    [SerializeField]
    GameObject WorldImage;

    [Header("フェードイン・アウトするスピード")]
    [SerializeField]
    Vector3 fadeSpeed;

    private Vector3 startScale;

    // Start is called before the first frame update
    void Start()
    {
        startScale = WorldImage.transform.localScale;
        WorldImage.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        WorldImage.transform.localScale -= fadeSpeed * Time.deltaTime;
    }

    public void FadeInWorld()
    {
        if(WorldImage.transform.localScale.x < startScale.x)
        {
            WorldImage.transform.localScale += fadeSpeed * Time.deltaTime;
        }
    }

    public void FadeOutWorld()
    {
        if (WorldImage.transform.localScale.x > startScale.x)
        {
            WorldImage.transform.localScale -= fadeSpeed * Time.deltaTime;
        }
    }
}
