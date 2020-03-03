using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grabbing : MonoBehaviour
{
    public GameObject touchingObject;
    public bool grabbing;
    public List<GameObject> grabbedobject;
    public Submarine submarine;
    Controller clawcontrols;
    public bool c_grabbing;

    void Update()
    {
        isGrabbing();
    }
    public void isGrabbing()
    {
        if (Input.GetMouseButton(0) && grabbedobject.Count == 0 && touchingObject.tag == "Grippable" ||
            c_grabbing == true && grabbedobject.Count == 0 && touchingObject.tag == "Grippable")
        {
            grabbing = true;
            grabbedobject.Add(touchingObject);
            touchingObject.transform.SetParent(transform);
            Vector3 scale = touchingObject.transform.localScale;
            Rigidbody rb = touchingObject.GetComponent<Rigidbody>();
            MeshCollider cc = touchingObject.GetComponent<MeshCollider>();
            rb.isKinematic = true;
            cc.isTrigger = true;
        }

        else if (Input.GetMouseButtonUp(0) || c_grabbing == false && submarine.mouseorgamepad == true) 
        {
            grabbing = false;
            grabbedobject.Remove(touchingObject);
            Rigidbody rb = touchingObject.GetComponent<Rigidbody>();
            MeshCollider cc = touchingObject.GetComponent<MeshCollider>();
            rb.isKinematic = false;
            cc.isTrigger = false;
            transform.DetachChildren();
        }
    }
    public void C_isGrabbing()
    {
        if (submarine.mouseorgamepad == true)
        {
            c_grabbing = true;
        }
    }
    public void C_releasingGrab()
    {
        if (submarine.mouseorgamepad == true)
        {
            c_grabbing = false;
        }
    }

        private void OnTriggerEnter(Collider targetCollider)
    {
        if (grabbing == false && grabbedobject.Count == 0)
        {
            touchingObject = targetCollider.gameObject;
        }
    }

    private void OnTriggerExit(Collider targetCollider)
    {
        if ( grabbing == false)
        {
            touchingObject = null;
        }
    }
}
