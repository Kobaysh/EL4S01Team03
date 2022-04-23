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

    [SerializeField] private TilemapController tileMap; // �^�C���}�b�v�R���g���[���[

    void Start()
    {
        mRespawnPosition = transform.position;
        mIsHide = false;

        if (!tileMap) tileMap = GameObject.Find("Tilemap").GetComponent<TilemapController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        bool HasInput = false;
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {         
            direction.x -= 1.0f;
            HasInput = true;
        }
        // �E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1.0f;
            HasInput = true;
        }
        // �O�Ɉړ�
        if (Input.GetKey(KeyCode.W))
        {          
            direction.y += 1.0f;
            HasInput = true;
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.S))
        {          
            direction.y -= 1.0f;
            HasInput = true;
        }

        if(HasInput)
        {
            Vector3 position = transform.position + Vector3.Normalize(direction) * mSpeed * Time.deltaTime;
            transform.position = position;

            float ZRotation = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x) + 90.0f;
            Quaternion targetRotation = Quaternion.Euler(0.0f, 0.0f, ZRotation);

            transform.rotation = targetRotation;
        }
       


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
