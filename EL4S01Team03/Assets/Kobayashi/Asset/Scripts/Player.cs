using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*プレイヤーの持つパラメータを参照*/
    private Vector3 pos;//プレイヤーの座標
    [SerializeField] private float moveSpeed;//プレイヤーの移動速度
    [SerializeField] private TilemapController tileMap; // タイルマップコントローラー
    [SerializeField] private bool isHiding = false;         // 隠れているか
    // Start is called before the first frame update
    void Start()
    {
        if (!tileMap) tileMap = GameObject.Find("Tilemap").GetComponent<TilemapController>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (Input.GetKey(KeyCode.W)) { pos.y += moveSpeed; }
        if (Input.GetKey(KeyCode.S)) { pos.y -= moveSpeed; }
        if (Input.GetKey(KeyCode.D)) { pos.x += moveSpeed; }
        if (Input.GetKey(KeyCode.A)) { pos.x -= moveSpeed; }

        transform.position = pos;

        if (tileMap)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (tileMap.CollisionHideTile(transform.position))
                {
                    isHiding = !isHiding;
                    Debug.Log("hide");
                }
            }
        }
    }

}
