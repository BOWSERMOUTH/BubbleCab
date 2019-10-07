using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {
    ParticleSystem splash;
    private bool isSplashing;
    AudioSource audiosource;
    public AudioClip sploosh;

	// Use this for initialization
	void Start ()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        splash = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeToSplash();
	}
    private void OnTriggerEnter(Collider splashing)
    {
        if (splashing.gameObject.tag == "Surface" && !audiosource.isPlaying)
        {
            isSplashing = true;
            audiosource.pitch = Random.Range(1, 3);
            audiosource.PlayOneShot(sploosh);
                    
        }
    }
    private void OnTriggerExit(Collider notSplashing)
    {
        isSplashing = false;
    }
    public void TimeToSplash()
    {
        if (isSplashing == true)
        {
            splash.enableEmission = true;  
        }
        else if (isSplashing == false)
        {
            splash.enableEmission = false;
        }
    }
}
