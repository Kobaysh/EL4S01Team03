using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public float time { set; get; }

    private TextMeshProUGUI text;

    
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        SetTime(0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        SetTime(time + Time.deltaTime);
    }

    public void SetTime(float value)
    {
        time = value;
        text.text = string.Format("{0:D4}", (int)time);
    }
}
