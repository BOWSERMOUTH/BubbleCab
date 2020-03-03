using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HullScript : MonoBehaviour
{
    private Text hullText;

   void Start ()
    {
		hullText = gameObject.GetComponent<Text>();
    }

	void Update ()
    {
        hullText.text = "HULL: " + GameManager.instance.subHull.ToString();
	}
}
