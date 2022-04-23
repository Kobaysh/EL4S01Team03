using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Time : MonoBehaviour
{
    public int time { set; get; }
    public int count;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        SetTime(1);
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetTime(int value)
    {
        time = value;
        text.text = string.Format("{0:D4}", time);
    }
}
