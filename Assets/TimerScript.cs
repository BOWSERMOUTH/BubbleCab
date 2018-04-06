using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public Submarine submarine;
    public Text timer;
    public float timeLeft = 30.0f;

    void Start()
    {
        timer = gameObject.GetComponent<Text>();
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        // if timeleft < 0)
        //{ Game Over }
        timer.text = "Time: " + timeLeft.ToString("F0");
    }
}