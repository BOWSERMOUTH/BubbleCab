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
    public GameObject retrylevel;
    private AudioSource pop;
    private Text timer;
    public float timeLeft;

    void Start()
    {
        retrylevel = GameObject.Find("RetryLevel");
        retrylevel.SetActive(false);
        pop = gameObject.GetComponent<AudioSource>();
        timer = gameObject.GetComponent<Text>();
        rb = submarine.GetComponent<Rigidbody>();
        bubbles = bubblesoff.GetComponent<ParticleSystem>();
    }

    private void TimerEnd()
    {
        retrylevel.SetActive(true);
        rb.isKinematic = true;
        submarine.rotationThrust = 0;
        bubbles.enableEmission = false;
    }
    public void retryLevel()
    {
        GameManager.instance.CurrentLevel();
        rb.isKinematic = false;
        submarine.rotationThrust = 150;
        bubbles.enableEmission = true;
        retrylevel.SetActive(false);
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = timeLeft.ToString("F0");
        if (timeLeft < 11 && timeLeft > 0 && pop.isPlaying == false)
        {
            pop.Play();
        }
            
        if (timeLeft < 0)
        {
            timer.text = "Game Over!";
            TimerEnd();
            if (timeLeft < 0)
            {
                timer.text = "Game Over!";
                TimerEnd();
                
            }
        }
    }
}