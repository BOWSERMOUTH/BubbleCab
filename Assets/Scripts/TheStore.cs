using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TheStore : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject panel;
    public GameObject openstoreon;
    public GameObject submarine;
    public GameObject exitstoregameobject;
    public bool openstorebool;
    public bool openstorebooldown;
    public Button openstore;
    public Button upgrade2flashlightbutton;
    public Button upgrade2boost;
    public Button upgrade2claw;
    public Button upgrade2radar;
    public Button repairhull;
    public Button upgrade2hull;
    public Button upgrade2carrying;
    public Button leavestore;
    private AudioSource audiosource;
    public AudioClip upgradenoise;
    public AudioClip repairnoise;
    [SerializeField] int repaircost = 100;
    [SerializeField] int firstupgrade = 500;
    [SerializeField] int secondupgrade = 1000;
    private float solidDistance = 3f;

    void Start ()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        var outsiderims = gameObject.GetComponent<Renderer>();
        var outsidewall = gameObject.GetComponent<Renderer>();
        upgrade2carrying.onClick.AddListener(carrying2ship);
        upgrade2hull.onClick.AddListener(hull2ship);
        upgrade2flashlightbutton.onClick.AddListener(flashlight2gamemanager);
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
            audiosource.PlayOneShot(upgradenoise);
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
            audiosource.PlayOneShot(upgradenoise);
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
            audiosource.PlayOneShot(upgradenoise);
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
            audiosource.PlayOneShot(upgradenoise);
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
            audiosource.PlayOneShot(upgradenoise);
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
            audiosource.PlayOneShot(upgradenoise);
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
            audiosource.PlayOneShot(repairnoise);
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

    private void OnTriggerEnter(Collider subenteredstore)
    {
        if (panel.activeSelf == false)
        {
            openstoreon.SetActive(true);
            openstorebool = true;
        }
    }

    private void OnTriggerExit(Collider subleftstore)
    {
        openstoreon.SetActive(false);
        openstorebool = false;
    }

        public void exitstore()
    {
        if (panel.activeSelf == true && openstorebooldown == false)
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
            submarine.GetComponent<Rigidbody>().isKinematic = false;
            print("i have exited the store");
        }
    }
    public void C_OpenStoreBooleon()
    {
        if (openstorebool == true && openstorebooldown == false)
        {
            openstoreon.SetActive(false);
            openstorebooldown = true;
            print("i've opened the store");
            submarine.GetComponent<Rigidbody>().isKinematic = true;
            panel.SetActive(true);
            eventSystem.SetSelectedGameObject(exitstoregameobject);
            openstorebool = false;
            CombinedButtonDisablers();
            Invoke("waitforcooldown", .1f);
        }
    }
    private void OpenStoreBooleon()
    {
        if (openstorebool == true && (Input.GetMouseButtonDown(0)))
        {
            //Time.timeScale = 0f;
            submarine.GetComponent<Rigidbody>().isKinematic = true;
            eventSystem.SetSelectedGameObject(exitstoregameobject);
            panel.SetActive(true);
            openstorebool = false;
            openstoreon.SetActive(false);
            CombinedButtonDisablers();
        }
    }
    private void waitforcooldown()
    {
        openstorebooldown = false;
        //Time.timeScale = 0f;
    }
    private void CombinedButtonDisablers()
    {
        ClawButtonDisabler();
        BoostButtonDisabler();
        FlashlightButtonDisabler();
        RadarButtonDisabler();
        RepairButtonDisabler();
        CapicityButtonDisabler();
        UpgradeHullButtonDisabler();
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
            upgrade2flashlightbutton.interactable = true;
        }
        else
        {
            upgrade2flashlightbutton.interactable = false;
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
