using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

    new Transform transform;
    public float growfactor = 5f;
	// Use this for initialization
	void Start ()
    {
        transform = gameObject.transform;
    }
	public void radaron()
    {
        transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growfactor;
    }
	// Update is called once per frame
	void Update () {
        radaron();
	}
}
