using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarUI : MonoBehaviour
{
    public TimeUI timeUI;
    public Slider slider;
    public float maxTime;
    float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        currentTime = maxTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = maxTime;
        currentTime = timeUI.time;
    }
}
