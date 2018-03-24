using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBubbles : MonoBehaviour {

    ParticleSystem winBubbles;
    public int winBubs = 1000;
	// Use this for initialization
	void Start ()
    {
        winBubbles = GetComponent<ParticleSystem>();
	}
    private void OnCollisionEnter(Collision collision)
    {
        winBubbles.maxParticles = winBubs;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
