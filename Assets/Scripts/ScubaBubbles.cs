using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScubaBubbles : MonoBehaviour
{
    public bool bubblesOn;
    ParticleSystem bubbles;

	void Start ()
    {
        bubbles = GetComponent<ParticleSystem>();
	}

    private void OnTriggerEnter(Collider surface)
    {
        if (surface.gameObject.tag == "Surface")
        {
            print("im colliding");
            bubbles.enableEmission = false;
        }
    }
}
