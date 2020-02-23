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

    public void TimerEnd()
    {
        Time.timeScale = 0f;
        retrylevel.SetActive(true);
        rb.isKinematic = true;
        submarine.rotationThrust = 0;
        bubbles.enableEmission = false;
    }
    public void retryLevel()
    {
        Time.timeScale = 1f;
        GameManager.instance.CurrentLevel();
        rb.isKinematic = false;
        submarine.rotationThrust = 150;
        bubbles.enableEmission = true;
        retrylevel.SetActive(false);
        submarine.invincibility = true;
        Invoke("TurnInvincibilityOff", 5f);
    }
    private void TurnInvincibilityOff()
    {
        submarine.invincibility = false;
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