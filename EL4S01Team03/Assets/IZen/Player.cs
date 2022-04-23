using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float mSpeed;
    private Vector3 mRespawnPosition;
    void Start()
    {
        mRespawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ç∂Ç…à⁄ìÆ
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = transform.position;
            position.x -= mSpeed * Time.deltaTime;
            transform.position = position;
        }
        // âEÇ…à⁄ìÆ
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = transform.position;
            position.x += mSpeed * Time.deltaTime;
            transform.position = position;
        }
        // ëOÇ…à⁄ìÆ
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = transform.position;
            position.y += mSpeed * Time.deltaTime;
            transform.position = position;
        }
        // å„ÇÎÇ…à⁄ìÆ
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = transform.position;
            position.y -= mSpeed * Time.deltaTime;
            transform.position = position;
        }
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = mRespawnPosition;
        }
    }
}
