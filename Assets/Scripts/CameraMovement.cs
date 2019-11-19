using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    GameObject player;
    Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        offset = player.transform.position - transform.position;
	}

    private void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
