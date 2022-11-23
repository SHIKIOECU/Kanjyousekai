using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    /* オブジェクトの取得 */
    [SerializeField] GameObject player;     // プレイヤー
    [SerializeField] GameObject satori;     // サトリ
    [SerializeField] GameObject savePoint;  // セーブポイント

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーをセーブポイントに移動させる
            player.transform.position = savePoint.transform.position;
            satori.transform.position = new Vector3(savePoint.transform.position.x - 1, savePoint.transform.position.y, savePoint.transform.position.z);
        }
    }
}
