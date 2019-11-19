using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheStore : MonoBehaviour {

    public static TheStore instance = null;
    public GameObject panel;
    public GameObject openstoreon;
    private bool openstorebool;
    public Button openstore;
    public Button upgrade2flashlight;
    public Button upgrade2boost;
    public Button upgrade2claw;
    public Button upgrade2radar;
    public Button repairhull;
    public Button upgrade2hull;
    public Button upgrade2carrying;
    public Button leavestore;
    [SerializeField] int repaircost = 100;
    [SerializeField] int firstupgrade = 400;
    [SerializeField] int secondupgrade = 800;
    [SerializeField] int thirdupgrade = 1600;
    
	void Start ()
    {
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
        if (Submarine.score >= secondupgrade)
        {
            Submarine.carryingCapacity = Submarine.carryingCapacity + 1;
            Submarine.score = Submarine.score - secondupgrade;
        }
    }

    public void hull2ship()
    {
        if (Submarine.score >= firstupgrade)
        {
            Submarine.hulllimit = Submarine.hulllimit + 1;
            Submarine.score = Submarine.score - firstupgrade;
        }
    }

    public void flashlight2gamemanager()
    {
        if (Submarine.score >= firstupgrade)
        {
            GameManager.instance.upgradedtolights = true;
            Submarine.score = Submarine.score - firstupgrade;
        }
    }

    public void boost2gamemanager()
    {
        if (Submarine.score >= firstupgrade)
        {
            GameManager.instance.upgradedtoboost = true;
            Submarine.score = Submarine.score - firstupgrade;
        }
    }

    public void claw2gamemanager()
    {
        if (Submarine.score >= firstupgrade)
        {
            
            GameManager.instance.upgradedtoclaw = true;
            Submarine.score = Submarine.score - firstupgrade;
        }
    }

    public void radar2gamemanager()
    {
        if (Submarine.score >= firstupgrade)
        {
            GameManager.instance.upgradedtoradar = true;
            Submarine.score = Submarine.score - firstupgrade;

        }
    }

    public void repair2ship()
    {
        if (Submarine.score >= repaircost)
        {
            Submarine.hull = Submarine.hull + 1;
            Submarine.score = Submarine.score - repaircost;
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
        openstorebool = !openstorebool;
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
        if (Submarine.score >= firstupgrade && GameManager.instance.upgradedtoboost == false)
        {
            upgrade2boost.interactable = true;
        }
        if (Submarine.score >= firstupgrade && GameManager.instance.upgradedtoclaw == false)
        {
            upgrade2claw.interactable = true;
        }
        if (Submarine.score >= firstupgrade && GameManager.instance.upgradedtolights == false)
        {
            upgrade2flashlight.interactable = true;
        }
        if (Submarine.score >= firstupgrade && GameManager.instance.upgradedtoradar == false)
        {
            upgrade2radar.interactable = true;
        }
        if (Submarine.score >= firstupgrade && Submarine.hulllimit < 6)
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
        if (Submarine.score >= repaircost && Submarine.hull < Submarine.hulllimit)
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
        if (Submarine.score >= secondupgrade && Submarine.carryingCapacity <= 2)
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
