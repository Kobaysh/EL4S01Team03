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
        //�Q�[���I�[�o�[��
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("GameOver");
        }

        //�N���A��
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Result");
        }

        //�Ă���
        if (Input.GetKey(KeyCode.A))
        {
            // �R���\�[���֕\��
            Debug.Log("debug comment");
        }
    }
}
