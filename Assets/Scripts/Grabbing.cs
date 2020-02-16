using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public GameObject touchingObject;
    public bool grabbing;
    public List<GameObject> grabbedobject;

    void Start()
    {

    }
    void Update()
    {
            isGrabbing();
        print(grabbedobject.Count);
    }
    private void isGrabbing()
    {
        if (Input.GetMouseButton(0) && grabbedobject.Count == 0 && touchingObject.tag == "Grippable")
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
        else if (Input.GetMouseButtonUp(0)) 
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
