using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー時
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("GameOver");
        }

        //クリア時
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Result");
        }

        //てすと
        if (Input.GetKey(KeyCode.A))
        {
            // コンソールへ表示
            Debug.Log("debug comment");
        }
    }
}
