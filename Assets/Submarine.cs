using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 150f;
    [SerializeField] float mainThrust = 1f;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        Thrust();
        Rotate();
	}
    // Controls
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
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
            rigidBody.AddRelativeForce(Vector3.down * mainThrust);
        }
    }
    private void Rotate()
    {
        // Freezing rotation as soon as we rotate
        rigidBody.freezeRotation = true;
        // Turning Power
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        // Rotating Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        // Rotating Right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationThisFrame);
        }
        // Allowing rotation to resume after rotating
        rigidBody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Ok");
                // Do Nothing
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
                print("Dead");
                break;
        }
    }
}
