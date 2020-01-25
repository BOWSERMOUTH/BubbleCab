using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheStore : MonoBehaviour {
    public GameObject panel;
    public GameObject openstoreon;
    public GameObject submarine;
    public bool openstorebool;
    public Button openstore;
    public Button upgrade2flashlight;
    public Button upgrade2boost;
    public Button upgrade2claw;
    //FIXME: Make this NOT static!
    public Button upgrade2radar;
    public Button repairhull;
    public Button upgrade2hull;
    public Button upgrade2carrying;
    public Button leavestore;
    [SerializeField] int repaircost = 100;
    [SerializeField] int firstupgrade = 400;
    [SerializeField] int secondupgrade = 800;
    private float solidDistance = 3f;
    
	void Start ()
    {
        var outsiderims = gameObject.GetComponent<Renderer>();
        var outsidewall = gameObject.GetComponent<Renderer>();
        upgrade2carrying.onClick.AddListener(carrying2ship);
        upgrade2hull.onClick.AddListener(hull2ship);
        upgrade2flashlight.onClick.AddListener(flashlight2gamemanager);
        upgrade2boost.onClick.AddListener(boost2gamemanager);
        upgrade2claw.onClick.AddListener(claw2gamemanager);
        upgrade2radar.onClick.AddListener(radar2gamemanager);
        repairhull.onClick.AddListener(repair2ship);
        leavestore.onClick.AddListener(exitstore);
	}

    public void carrying2ship()
    {
        if (GameManager.instance.score >= secondupgrade)
        {
            GameManager.instance.subCarryingCapacity += 1;
            GameManager.instance.score -= secondupgrade;
        }
    }

    public void hull2ship()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.subHullLimit += 1;
            GameManager.instance.score -= firstupgrade;
        }
    }

    public void flashlight2gamemanager()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.upgradedtolights = true;
            GameManager.instance.score -= firstupgrade;
        }
    }

    public void boost2gamemanager()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.upgradedtoboost = true;
            GameManager.instance.score -= firstupgrade;
        }
    }

    public void claw2gamemanager()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            
            GameManager.instance.upgradedtoclaw = true;
            GameManager.instance.score -= firstupgrade;
        }
    }

    public void radar2gamemanager()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.upgradedtoradar = true;
            GameManager.instance.score -= firstupgrade;

        }
    }

    public void repair2ship()
    {
        if (GameManager.instance.score >= repaircost)
        {
            GameManager.instance.subHull += 1;
            GameManager.instance.score -= repaircost;
        }
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
        openstorebool = false;
    }

    private void OpenStoreBooleon()
    {
        if (openstorebool == true && (Input.GetMouseButtonDown(0)))
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            openstorebool = false;
            openstoreon.SetActive(false);
        }
    }

    public void ButtonDisabler400()
    {
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.upgradedtoboost == false)
        {
            upgrade2boost.interactable = true;
        }
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.upgradedtoclaw == false)
        {
            upgrade2claw.interactable = true;
        }
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.upgradedtolights == false)
        {
            upgrade2flashlight.interactable = true;
        }
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.upgradedtoradar == false)
        {
            upgrade2radar.interactable = true;
        }
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.subHullLimit < 6)
        {
            upgrade2hull.interactable = true;
        }
        else
        {
            upgrade2boost.interactable = false;
            upgrade2claw.interactable = false;
            upgrade2flashlight.interactable = false;
            upgrade2radar.interactable = false;
            upgrade2hull.interactable = false;
        }
    }

    private void ButtonDisabler100()
    {
        if (GameManager.instance.score >= repaircost && GameManager.instance.subHull < GameManager.instance.subHullLimit)
        {
            repairhull.interactable = true;
        }
        else
        {
            repairhull.interactable = false;
        }
    }

    private void ButtonDisabler800()
    {
        if (GameManager.instance.score >= secondupgrade && GameManager.instance.subCarryingCapacity <= 2)
        {
            upgrade2carrying.interactable = true;
        }
        else
        {
            upgrade2carrying.interactable = false;
        }
    }
    void Update ()
    {
        OpenStoreBooleon();
        ButtonDisabler100();
        ButtonDisabler400();
        ButtonDisabler800();
	}
}
