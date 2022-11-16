using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatoriController : MonoBehaviour
{
    [SerializeField] GameObject target = null;  // 追従する対象
    [SerializeField] SpriteRenderer satori;     // サトリのスプライト

    //[SerializeField] Sprite right_sp, left_sp;

    [SerializeField] Sprite[] right_sp = new Sprite[15];    // 右向きのスプライト
    [SerializeField] Sprite[] left_sp = new Sprite[15];     // 左向きのスプライト

    [SerializeField] float speed;           // 移動スピード
    [SerializeField] float dis_x, dis_y;    // キャラクターとの距離

    bool isRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DirectChange();
        //Move();
        Move2();
        //Move3();
    }

    // サトリの移動(距離の条件あり)
    private void Move()
    {
        float distance_x = DistanceX(target);  // 条件のX座標の距離
        float distance_y = DistanceY(target);  // 条件のY座標の距離
        //Debug.Log(distance_x);

        // キャラクターと一定以上離れたら移動する
        if (distance_x > 2)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x - dis_x, target.transform.position.y + dis_y, -1), speed * Time.deltaTime);
        }
        else if (distance_x < -2)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x + dis_x, target.transform.position.y + dis_y, -1), speed * Time.deltaTime);
        }
        else
        {
            //Move2();
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, target.transform.position.y + dis_y, -1), speed * Time.deltaTime);
        }
    }

    // サトリの移動(条件なし)
    private void Move2()
    {
        //キャラクターの向きを変更したらすぐに移動する
        if (DirectCheck(right_sp, isRight))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x - dis_x, target.transform.position.y + dis_y, -1), speed * Time.deltaTime);
        }
        else if (DirectCheck(left_sp, isRight))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x + dis_x, target.transform.position.y + dis_y, -1), speed * Time.deltaTime);
        }
    }

    // どっちを向いているかをスプライトから判断する処理
    private bool DirectCheck(Sprite[] sprites, bool direct)
    {
        foreach (Sprite sprite in sprites)
        {
            if (target.GetComponent<SpriteRenderer>().sprite == sprite)
            {
                direct = true;
                break;
            }
            direct = false;
        }

        return direct;
    }

    // サトリの向きの変更
    private void DirectChange()
    {
        if (this.transform.position.x >= target.transform.position.x)
        {
            // 左向き
            satori.flipX = true;
        }
        else
        {
            // 右向き
            satori.flipX = false;
        }
    }

    // プレイヤーとサトリのX座標の距離の計算
    private float DistanceX(GameObject target)
    {
        float distance_x = 0.0f;

        distance_x = target.transform.position.x - this.transform.position.x;

        return distance_x;
    }

    // プレイヤーとサトリのY座標の距離の計算
    private float DistanceY(GameObject target)
    {
        float distance_y = 0.0f;

        distance_y = target.transform.position.y - this.transform.position.y;

        return distance_y;
    }
}
