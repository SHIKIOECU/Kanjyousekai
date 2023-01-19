using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class FatherController : NPCBase
{
    public enum FatherState
    {
        FLUSTERED, MOVE, SHOUT
    }
    public FatherState State;

    // LostBoyの取得
    [SerializeField] GameObject lostBoy;

    // Canvasの取得
    [SerializeField] GameObject canvas;

    // ポジション
    Vector3 nowPos = new Vector3(19.1f, 1.0f, 0.0f);
    Vector3 targetPos = new Vector3(37.0f, 1.0f, 0.0f);

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

        if (lostBoy.GetComponent<LostBoyController>().isReunion)
        {
            canvas.SetActive(false);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            canvas.SetActive(true);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public override int WordTerm()
    {
        return (int)State;
    }

    void MoveToBoy()
    {
        nowSpeed += Time.deltaTime * speed;

        transform.position = Vector3.Slerp(nowPos, targetPos, nowSpeed);
        Debug.Log("MoveToBoyが呼ばれました");

        if (transform.position == targetPos) isFather = false; lostBoy.GetComponent<LostBoyController>().isReunion = true;
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
