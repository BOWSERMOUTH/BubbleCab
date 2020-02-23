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
    public Button upgrade2radar;
    public Button repairhull;
    public Button upgrade2hull;
    public Button upgrade2carrying;
    public Button leavestore;
    [SerializeField] int repaircost = 100;
    [SerializeField] int firstupgrade = 500;
    [SerializeField] int secondupgrade = 1000;
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
            GameManager.instance.subUpgradedCapacity += 1;
            GameManager.instance.subCarryingCapacity += 1;
            GameManager.instance.score -= secondupgrade;
            ClawButtonDisabler();
            BoostButtonDisabler();
            FlashlightButtonDisabler();
            RadarButtonDisabler();
            RepairButtonDisabler();
            CapicityButtonDisabler();
            UpgradeHullButtonDisabler();
        }
    }

    public void hull2ship()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.subHullLimit += 1;
            GameManager.instance.score -= firstupgrade;
            ClawButtonDisabler();
            BoostButtonDisabler();
            FlashlightButtonDisabler();
            RadarButtonDisabler();
            RepairButtonDisabler();
            CapicityButtonDisabler();
            UpgradeHullButtonDisabler();
        }
    }

    public void flashlight2gamemanager()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.upgradedtolights = true;
            GameManager.instance.score -= firstupgrade;
            ClawButtonDisabler();
            BoostButtonDisabler();
            FlashlightButtonDisabler();
            RadarButtonDisabler();
            RepairButtonDisabler();
            CapicityButtonDisabler();
            UpgradeHullButtonDisabler();
        }
    }
    public void boost2gamemanager()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.upgradedtoboost = true;
            GameManager.instance.score -= firstupgrade;
            ClawButtonDisabler();
            BoostButtonDisabler();
            FlashlightButtonDisabler();
            RadarButtonDisabler();
            RepairButtonDisabler();
            CapicityButtonDisabler();
            UpgradeHullButtonDisabler();
        }
    }
    public void claw2gamemanager()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.upgradedtoclaw = true;
            GameManager.instance.score -= firstupgrade;
            ClawButtonDisabler();
            BoostButtonDisabler();
            FlashlightButtonDisabler();
            RadarButtonDisabler();
            RepairButtonDisabler();
            CapicityButtonDisabler();
            UpgradeHullButtonDisabler();
        }
    }

    public void radar2gamemanager()
    {
        if (GameManager.instance.score >= firstupgrade)
        {
            GameManager.instance.upgradedtoradar = true;
            GameManager.instance.score -= firstupgrade;
            ClawButtonDisabler();
            BoostButtonDisabler();
            FlashlightButtonDisabler();
            RadarButtonDisabler();
            RepairButtonDisabler();
            CapicityButtonDisabler();
            UpgradeHullButtonDisabler();
        }
    }
    public void repair2ship()
    {
        if (GameManager.instance.score >= repaircost)
        {
            GameManager.instance.subHull += 1;
            GameManager.instance.score -= repaircost;
            ClawButtonDisabler();
            BoostButtonDisabler();
            FlashlightButtonDisabler();
            RadarButtonDisabler();
            RepairButtonDisabler();
            CapicityButtonDisabler();
            UpgradeHullButtonDisabler();
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
            ClawButtonDisabler();
            BoostButtonDisabler();
            FlashlightButtonDisabler();
            RadarButtonDisabler();
            RepairButtonDisabler();
            CapicityButtonDisabler();
            UpgradeHullButtonDisabler();
        }
    }
    public void ClawButtonDisabler()
    {
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.upgradedtoclaw == false)
        {
            upgrade2claw.interactable = true;
        }
        else
        {
            upgrade2claw.interactable = false;
        }
    }
    public void BoostButtonDisabler()
    {
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.upgradedtoboost == false)
        {
            upgrade2boost.interactable = true;
        }
        else
        {
            upgrade2boost.interactable = false;
        }
    }
    public void RadarButtonDisabler()
    {
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.upgradedtoradar == false)
        {
            upgrade2radar.interactable = true;
        }
        else
        {
            upgrade2radar.interactable = false;
        }
    }
    public void FlashlightButtonDisabler()
    {
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.upgradedtolights == false)
        {
            upgrade2flashlight.interactable = true;
        }
        else
        {
            upgrade2flashlight.interactable = false;
        }
    }
    public void UpgradeHullButtonDisabler()
    {
        if (GameManager.instance.score >= firstupgrade && GameManager.instance.subHullLimit < 6)
        {
            upgrade2hull.interactable = true;
        }
        else
        {
            upgrade2hull.interactable = false;
        }
    }

    private void RepairButtonDisabler()
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

    private void CapicityButtonDisabler()
    {
        if (GameManager.instance.score >= secondupgrade && GameManager.instance.subCarryingCapacity < 2)
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
    }
}
