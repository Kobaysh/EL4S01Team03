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
        //時間を取得してランクの変動を確認
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
    
    //ランクをセット
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
