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
    // You are now touching the object bool
    void OnTriggerEnter(Collider targetCollider)
    {
        if (targetCollider.gameObject.tag == "Grippable")
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
        if (Input.GetMouseButtonDown(0) && touchingObject == true)
            {
                Vector3 scale = cube.transform.localScale;
                cube.transform.parent = transform;
                Rigidbody rb = cube.GetComponent<Rigidbody>();
                CapsuleCollider cc = cube.GetComponent<CapsuleCollider>();
                cc.isTrigger = true;
                rb.isKinematic = true;
            }
        else if (Input.GetMouseButtonUp(0) && touchingObject == true)
            {
                Rigidbody rb = cube.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                CapsuleCollider cc = cube.GetComponent<CapsuleCollider>();
                cc.isTrigger = false;
                transform.DetachChildren();
            }
    }
    void Update()
    {

    }
}