using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        ProcessInput();
	}
    // Controls
    private void ProcessInput()
    {
        // Thrust
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            // So audio doesn't layer
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.S))
        {
            print("going down");
            rigidBody.AddRelativeForce(Vector3.down);
        }
        // Rotating Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        // Rotating Right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back);
        }
    }
}
