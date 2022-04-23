using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    public TimeUI timeUI;

   // [SerializeField] float timeS;
    [SerializeField] float timeA;
    [SerializeField] float timeB;

    string rankText;

    // Start is called before the first frame update
    void Start()
    {
        SetRank("S");
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ��擾���ă����N�̕ϓ����m�F
        float time = timeUI.time;

        if (time > timeB)
        {
            SetRank("B");
        }
        else if (time > timeA)
        {
            SetRank("A");
        }
    }
    
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
}
