using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawsOfLife2 : MonoBehaviour {
    public float distance;
    float originalY;
    Vector3 targetPosition;

    void Awake()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude + distance;
        targetPosition = new Vector3(mouseRay.origin.x, originalY, mouseRay.origin.z);

        transform.LookAt(targetPosition * midPoint);
    }
}
