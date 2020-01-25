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
    void Update()
    {
        isGrabbing();
    }
    private void isGrabbing()
    {
        if (Input.GetMouseButton(0) && grabbing == false && touchingObject.tag == "Grippable")
        {
            print("I am touching " + touchingObject);
            touchingObject.transform.SetParent(transform);
            Vector3 scale = touchingObject.transform.localScale;
            Rigidbody rb = touchingObject.GetComponent<Rigidbody>();
            MeshCollider cc = touchingObject.GetComponent<MeshCollider>();
            rb.isKinematic = true;
            cc.isTrigger = true;
            grabbing = true;
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            print("i've released the mouse");
            Rigidbody rb = touchingObject.GetComponent<Rigidbody>();
            MeshCollider cc = touchingObject.GetComponent<MeshCollider>();
            rb.isKinematic = false;
            cc.isTrigger = false;
            transform.DetachChildren();
            grabbing = false;
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
}
