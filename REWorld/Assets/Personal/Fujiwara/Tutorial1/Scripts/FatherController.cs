using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class FatherController : NPCBase
{
    // LostBoyの取得
    [SerializeField] GameObject lostBoy;

    // ポジション
    Vector3 nowPos = new Vector3(19.1f, 2.0f, 0.0f);
    Vector3 targetPos = new Vector3(37.0f, 2.0f, 0.0f);

    // 移動スピード
    [SerializeField] float speed;
    float nowSpeed;

    // 観測されたどうか
    public bool isFather;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        isFather = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lostBoy.GetComponent<LostBoyController>().isFather) MoveToBoy();
    }

    void MoveToBoy()
    {
        nowSpeed += Time.deltaTime * speed;

        transform.position = Vector3.Slerp(nowPos, targetPos, nowSpeed);
        Debug.Log("MoveToBoyが呼ばれました");

        if (transform.position == targetPos) isFather = false;
    }

    public override void AppearanceWorld()
    {
        base.AppearanceWorld();
    }

    public override void DisappearanceWorld()
    {
        base.DisappearanceWorld();
    }
}
