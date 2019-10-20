using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesOnThrust : MonoBehaviour {

    ParticleSystem bubbleThrust;
    public bool isColliding;
	// Use this for initialization
	void Start ()
    {
        bubbleThrust = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update ()
    {
        BubblesGo();
        TurnOffBubblesIfColliding();
    }
    private void BubblesGo()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ParticleSystem.ShapeModule shape = bubbleThrust.shape;
            bubbleThrust.enableEmission = true;
            shape.angle = 0;
            bubbleThrust.maxParticles = 160;
            bubbleThrust.emissionRate = 49;
            {
                if (Input.GetKey(KeyCode.LeftShift) && GameManager.instance.upgradedtoboost == true)
                {
                    bubbleThrust.emissionRate = 160;
                    shape.angle = 28.6f;
                    bubbleThrust.enableEmission = true;
                }
            }
        }
        
        else bubbleThrust.enableEmission = false;
    }
    // Once you exit the water, toggle bubbles off
    public void OnTriggerEnter(Collider nobubsoutside)
    {
        if (nobubsoutside.gameObject.tag == "Surface")
            {
            isColliding = true;
            }
    }
    // Once you land back in water, toggle bubbles on
    public void OnTriggerExit(Collider returntowater)
    {
        isColliding = false;
    }
    // Toggle between bubbles on and off 
    public void TurnOffBubblesIfColliding()
    {
        if (isColliding == true)
        {
            bubbleThrust.enableEmission = false;
        }
        else if (isColliding == false)
        {
            bubbleThrust.enableEmission = true;
        }
    }
}
