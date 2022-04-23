using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float mSpeed;
    private Vector3 mRespawnPosition;
    private bool mIsHide;
    [SerializeField]
    private GameObject mBodySprite;

    [SerializeField] private TilemapController tileMap; // タイルマップコントローラー

    void Start()
    {
        mRespawnPosition = transform.position;
        mIsHide = false;

        if (!tileMap) tileMap = GameObject.Find("Tilemap").GetComponent<TilemapController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 左に移動
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = transform.position;
            position.x -= mSpeed * Time.deltaTime;
            transform.position = position;
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = transform.position;
            position.x += mSpeed * Time.deltaTime;
            transform.position = position;
        }
        // 前に移動
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = transform.position;
            position.y += mSpeed * Time.deltaTime;
            transform.position = position;
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = transform.position;
            position.y -= mSpeed * Time.deltaTime;
            transform.position = position;
        }

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    HideStart();
        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    HideEnd();
        //}

        if (tileMap)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (tileMap.CollisionHideTile(transform.position))
                {
                    HideStart();
                    Debug.Log("hideStart");
                }
            
            }

            if (!tileMap.CollisionHideTile(transform.position))
            {
                HideEnd();
                Debug.Log("hideEnd");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(!mIsHide)
            {
                transform.position = mRespawnPosition;
            }            
        }
    }

    public void HideStart()
    {
        if(!mIsHide)
        {
            mIsHide = true;
            if(mBodySprite)
            {
                mBodySprite.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,0.3f);                
            }
        }
    }

    public void HideEnd()
    {
        if(mIsHide)
        {
            mIsHide = false;
            if (mBodySprite)
            {
                mBodySprite.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
}
