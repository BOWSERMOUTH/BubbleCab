using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

    Rigidbody rigidBody;

	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        ProcessInput();
	}
    // Controls
    private void ProcessInput()
    {
        // Thrust
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
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
