using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RankUI : MonoBehaviour
{
    /*
    private TextMeshProUGUI text;
    public TimeUI timeUI;

   // [SerializeField] float timeS;
    [SerializeField] float timeA;
    [SerializeField] float timeB;

    string rankText;

    // Start is called before the first frame update
    void Start()
    {
        rankText = "S";
    }

    // Update is called once per frame
    void Update()
    {
        
        //���Ԃ��擾���ă����N�̕ϓ����m�F
        float time = timeUI.time;

        if (time > timeB)
        {
            if (rankText.Equals("B")) return;
            rankText = "B";
            text.text = string.Format("0", rankText);
        }

        else if (time > timeA)
        {
            if (rankText.Equals("B")) return;
            rankText = "A";
            text.text = string.Format("0", rankText);
        }
        
    }
    
    /*
    //�����N���Z�b�g
    public void SetRank(string rank)
    {
        if (rankText.Equals(rank))
        {
            return;
        }

        rankText = rank;
        text.text = string.Format("Rank 0",rankText);
    }
    */
    
}
