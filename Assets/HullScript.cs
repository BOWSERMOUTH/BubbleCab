using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HullScript : MonoBehaviour
{
    public Submarine submarine;
    public Text hullText;
	// Use this for initialization
	void Start ()
    {
		hullText = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        hullText.text = "Hull: " + Submarine.hull.ToString();
	}
}
