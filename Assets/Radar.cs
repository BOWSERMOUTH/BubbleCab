using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

    private ParticleSystem ps;
    public GameObject submarine;
    private float growfactor = 6f;
    public bool radarcooldowntoggle;
	// Use this for initialization
	void Start ()
    {
        ps = GetComponent<ParticleSystem>();
        submarine = GameObject.Find("Submarine");
    }
	public void radaron()
    {
        if (radarcooldowntoggle == true)
        {
            ps.enableEmission = true;
            ParticleSystem.ShapeModule shape = ps.shape;
            shape.radius = shape.radius + Time.deltaTime * growfactor;
            gameObject.transform.parent = null;
            if (shape.radius > 30)
            {
                resetradar();
                shape.radius = 1f;
                ps.enableEmission = false;
                radarcooldowntoggle = false;
            }
        }
    }
    public void resetradar()
    {
        gameObject.transform.parent = submarine.transform;
        gameObject.transform.position = submarine.transform.position;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && radarcooldowntoggle == false)
            {
            radarcooldowntoggle = true;
            }
        radaron();
	}
}
