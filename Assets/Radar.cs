using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

    private ParticleSystem ps;
    public GameObject submarine;
    private SphereCollider radarcollider;
    private float growfactor = 6f;
    public bool radarcooldowntoggle;
    private AudioSource audioSource;
    private AudioClip beep;
	// Use this for initialization
	void Start ()
    {
        radarcollider = GetComponent<SphereCollider>();
        ps = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        beep = audioSource.clip;
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Diver")
        {
            float dist = Vector3.Distance(submarine.transform.position, collider.transform.position);
            print(dist);
        }
    }
    public void RadarOn()
    {
        if (radarcooldowntoggle == true)
        {
            audioSource.enabled = true;
            ps.enableEmission = true;
            ParticleSystem.ShapeModule shape = ps.shape;
            radarcollider.radius = radarcollider.radius + Time.deltaTime * growfactor;
            shape.radius = shape.radius + Time.deltaTime * growfactor;
            if (shape.radius > 30)
            {
                radarcollider.radius = 0f;
                shape.radius = 1f;
                ps.enableEmission = false;
                radarcooldowntoggle = false;
                audioSource.enabled = false;
            }
        }
    }
    public void ResetRadarPosition()
    {
        if (radarcooldowntoggle == false)
        {
            transform.position = submarine.transform.position;
        }
    }
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space) && radarcooldowntoggle == false)
        {
            radarcooldowntoggle = true;
        }
        RadarOn();
        ResetRadarPosition();
	}
}
