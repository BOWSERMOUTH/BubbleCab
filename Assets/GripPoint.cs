using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripPoint : MonoBehaviour
{
    public bool touchingObject;

    void Start()
    {
        touchingObject = false;
    }
    // You are not touching the object bool
    void OnTriggerEnter(Collider poop)
    {
        if (poop.gameObject.tag == "Grippable")
        {
            touchingObject = true;
        }
        else
        {
            touchingObject = false;
        }
    }
    // You are now NOT touching the object bool
    void OnTriggerExit(Collider cube)
        
    {
        touchingObject = false;
    }


    void OnTriggerStay(Collider cube)
    {
            if (Input.GetKeyDown(KeyCode.Mouse0) && touchingObject == true)
            {
                print("i'm gripping");
                Vector3 scale = cube.transform.localScale;
                cube.transform.parent = transform;
                Rigidbody rb = cube.GetComponent<Rigidbody>();

                //cube.transform.localScale = scale;
                rb.isKinematic = true;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            transform.DetachChildren();
        }
    }

    void Update()
    {

    }
}