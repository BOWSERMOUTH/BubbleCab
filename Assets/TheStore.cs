using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheStore : MonoBehaviour {

    public GameObject panel;
    public GameObject openstoreon;
    private bool openstorebool;
    public Button openstore;
    public Button upgrade2flashlight;
    public Button leavestore;
    
    

	// Use this for initialization
	void Start ()
    {
        upgrade2flashlight.onClick.AddListener(flashlight2gamemanager);
        leavestore.onClick.AddListener(exitstore);
	}
    public void flashlight2gamemanager()
    {
        
        GameManager.instance.upgradedtolights = true;
    }

    public void exitstore()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider subenteredstore)
    {
        openstoreon.SetActive(true);
        openstorebool = true;
    }
    private void OnTriggerExit(Collider subleftstore)
    {
        openstoreon.SetActive(false);
        openstorebool = !openstorebool;
    }
    private void OpenStoreBooleon()
    {
        if (openstorebool == true && (Input.GetMouseButtonDown(0)))
        {
            Time.timeScale = 0f;
            print("i've clicked");
            panel.SetActive(true);
            openstorebool = false;
            openstoreon.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update ()
    {
        OpenStoreBooleon();
	}
}
