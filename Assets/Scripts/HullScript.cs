using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HullScript : MonoBehaviour
{
    private Text hullText;
    //public Camera camera;
    //public Transform camTransform;
    //public float shakeDuration = 0f;
    //public float shakeAmount = 0.7f;
    //public float decreaseFactor = 1.0f;
   // Vector3 originalPos;
	// Use this for initialization
	void Start ()
    {
		hullText = gameObject.GetComponent<Text>();
        //originalPos = camTransform.localPosition;
    }
	//public void cameraShake()
   // {
        //camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
       // shakeDuration -= Time.deltaTime * decreaseFactor;
    //}
	// Update is called once per frame
	void Update ()
    {
        hullText.text = "HULL: " + Submarine.hull.ToString();
	}
}
