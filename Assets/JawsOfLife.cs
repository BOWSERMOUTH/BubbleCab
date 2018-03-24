using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawsOfLife : MonoBehaviour
{
    public float distance;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude + distance;

        transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint);
    }
}