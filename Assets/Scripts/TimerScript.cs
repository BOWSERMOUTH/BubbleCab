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
    private AudioSource pop;
    private Text timer;
    public float timeLeft;


    void Start()
    {
        pop = gameObject.GetComponent<AudioSource>();
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
        timer.text = timeLeft.ToString("F0");
        {
            if (timeLeft < 11 && timeLeft > 0 && pop.isPlaying == false)
            {
                pop.Play();
            }
            
        }
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