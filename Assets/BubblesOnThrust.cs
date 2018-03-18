using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesOnThrust : MonoBehaviour {

    ParticleSystem bubbleThrust;

	// Use this for initialization
	void Start ()
    {
        bubbleThrust = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        BubblesGo();
    }

    private void BubblesGo()
    {
        if (Input.GetKey(KeyCode.W))
        {
            bubbleThrust.enableEmission = true;
        }
        else
        {
            bubbleThrust.enableEmission = false;
        }
    }
}
