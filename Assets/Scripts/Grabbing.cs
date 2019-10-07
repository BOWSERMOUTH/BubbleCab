using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{

    public GameObject touchingObject;
    public bool grabbing;

    void Start()
    {

    }
    private void isGrabbing()
    {
        if (grabbing == true && (Input.GetMouseButton(0) && touchingObject.tag == "Grippable"))
        {
            print("I am touching " + touchingObject);
            Vector3 scale = touchingObject.transform.localScale;
            touchingObject.transform.parent = transform;
            Rigidbody rb = touchingObject.GetComponent<Rigidbody>();
            CapsuleCollider cc = touchingObject.GetComponent<CapsuleCollider>();
            cc.isTrigger = true;
            rb.isKinematic = true;
        }
        else if (grabbing == false && touchingObject.tag == "Grippable")
        {
            Rigidbody rb = touchingObject.GetComponent<Rigidbody>();
            CapsuleCollider cc = touchingObject.GetComponent<CapsuleCollider>();
            rb.isKinematic = false;
            cc.isTrigger = false;
            transform.DetachChildren();
        }
    }

    private void OnTriggerEnter(Collider targetCollider)
    {
        touchingObject = targetCollider.gameObject;
    }
    private void OnTriggerExit(Collider targetCollider)
    {
        touchingObject = null;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && touchingObject.tag == "Grippable")
        {
            grabbing = true;
        }
        else// if (Input.GetMouseButtonUp(0) && touchingObject.tag == "Grippable")
        {
            grabbing = false;
        }
        isGrabbing();
    }
}
