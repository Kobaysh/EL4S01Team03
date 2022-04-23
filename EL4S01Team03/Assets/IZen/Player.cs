using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float mSpeed;
    private Vector3 mRespawnPosition;
    private bool mIsHide;
    private bool mIsGoal;
    [SerializeField]
    private GameObject mBodySprite;
    private GameObject mMainCamera;
    [SerializeField]
    private GameObject goalText;

    [SerializeField] private TilemapController tileMap; // タイルマップコントローラー

    void Start()
    {
        mRespawnPosition = transform.position;
        mMainCamera = GameObject.Find("Main Camera");
        mIsHide = false;
        mIsGoal = false;
        if (!tileMap) tileMap = GameObject.Find("Tilemap").GetComponent<TilemapController>();

        if (mMainCamera)
        {
            Vector3 position = transform.position;
            position.z = -10.0f;
            mMainCamera.transform.position = position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        bool HasInput = false;
        // 左に移動
        if (Input.GetKey(KeyCode.A))
        {         
            direction.x -= 1.0f;
            HasInput = true;
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1.0f;
            HasInput = true;
        }
        // 前に移動
        if (Input.GetKey(KeyCode.W))
        {          
            direction.y += 1.0f;
            HasInput = true;
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.S))
        {          
            direction.y -= 1.0f;
            HasInput = true;
        }

        if(HasInput)
        {
            Vector3 position = transform.position + Vector3.Normalize(direction) * mSpeed * Time.deltaTime;
            transform.position = position;
            position.z = -10.0f;
            if(mMainCamera)
            {
                mMainCamera.transform.position = position;
            }
            
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
            if (tileMap.CollisionGoalTile(transform.position))
            {
                if (!mIsGoal)
                {
                    mIsGoal = true;
                    GameObject.Find("PostVolume").SetActive(false);
                    goalText.SetActive(true);
                }
            }
        }

        if (mIsGoal)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Result");
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
