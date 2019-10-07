using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Submarine submarine;
    public Rigidbody rb;
    public BubblesOnThrust bubblesoff;
    public ParticleSystem bubbles;
    private Text timer;
    public float timeLeft = 30.0f;

    void Start()
    {
        timer = gameObject.GetComponent<Text>();
        rb = submarine.GetComponent<Rigidbody>();
        bubbles = bubblesoff.GetComponent<ParticleSystem>();
    }
    private void TimerEnd()
    {
        rb.isKinematic = true;
        submarine.rotationThrust = 0;
        bubbles.enableEmission = false;
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = "Time: " + timeLeft.ToString("F0");
        {
            if (timeLeft < 0)
            {
                timer.text = "Game Over!";
                TimerEnd();
                print("timer ended");
            }
        }
    }
}