using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*�v���C���[�̎��p�����[�^���Q��*/
    private Vector3 pos;//�v���C���[�̍��W
    [SerializeField] private float moveSpeed;//�v���C���[�̈ړ����x
    [SerializeField] private TilemapController tileMap; // �^�C���}�b�v�R���g���[���[
    [SerializeField] private bool isHiding = false;         // �B��Ă��邩
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
