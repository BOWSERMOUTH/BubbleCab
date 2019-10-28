using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool charactertoggle;
    public GameObject po;
    public GameObject penny;
    private GameObject toplightbulb;
    private GameObject rearrightbulb;
    private GameObject rearleftbulb;
    public GameObject radar;
    public GameObject radarpic;
    public GameObject theClaw;
    public GameObject diverSpawnScript;

    // SPAWN DIVER LOGIC
    public Vector3[] spawnPoints;
    public Vector3[] treasureSpawnPoints;
    public int maxDivers = 3;
    public int maxTreasures = 5;
    public GameObject diver;
    public GameObject treasurechest;
    public List<int> treasureIds;
    public List<int> usedIds;
    int diverrandom;
    int treasurerandom;

    // ABILITY UPGRADES
    public bool upgradedtolights;
    public bool upgradedtoradar;
    public bool upgradedtoboost;
    public bool upgradedtoclaw;




    void Start ()
    {
        po = GameObject.Find("popo");
        penny = GameObject.Find("PennyModel");
        toplightbulb = GameObject.Find("TopLightBulb");
        rearleftbulb = GameObject.Find("LeftLightBulb");
        rearrightbulb = GameObject.Find("RightLightBulb");
        radar = GameObject.Find("Radar");
        radarpic = GameObject.Find("radarpic");
        theClaw = GameObject.Find("ArmPivotPoint");
    }
    void Awake ()
    {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    // Tells divers to spawn in random locations
    private void spawnDiverIntro()
    {
        do
        {
            diverrandom = Random.Range(0, spawnPoints.Length);
        }
        while (usedIds.IndexOf(diverrandom) != -1);

        usedIds.Add(diverrandom);
        Instantiate(diver, spawnPoints[diverrandom], Quaternion.Euler(0, -90, 0));
        maxDivers = maxDivers - 1;
    }
    private void spawnTreasureIntro()
    {
        do
        {
            treasurerandom = Random.Range(0, treasureSpawnPoints.Length);
        }
        while (treasureIds.IndexOf(treasurerandom) != -1);

        treasureIds.Add(treasurerandom);
        Instantiate(treasurechest, treasureSpawnPoints[treasurerandom], Quaternion.Euler(-90, -90, 0));
        maxTreasures = maxTreasures - 1;
    }
    public void whosplaying()
    {
        if (charactertoggle == true)
        {
            po.SetActive(true);
            penny.SetActive(false);
        }
        else
        {
            po.SetActive(false);
            penny.SetActive(true);
        }
    }
    public void upgraded2radar()
    {
        if (upgradedtoradar == true)
        {
            radar.SetActive(true);
            radarpic.SetActive(true);
        }
        else
        {
            radar.SetActive(false);
            radarpic.SetActive(false);
        }
    }
    public void upgraded2claw()
    {
        if (upgradedtoclaw == true)
        {
            theClaw.SetActive(true);
            print("i've turned the claw on");
        }
        else
        {
            theClaw.SetActive(false);
            print("i've turned the claw off");
        }
    }
    public void diverspawnonupdate()
    {
        if (maxDivers < 1)
        {
            return;
        }
        else
            spawnDiverIntro();
    }
    public void treasurespawnonupdate()
    {
        if (maxTreasures < 1)
        {
            return;
        }
        else
            spawnTreasureIntro();
    }

    // Update is called once per frame
    void Update () {
        SceneManager.sceneLoaded += OnSceneLoaded;
        whosplaying();
        upgraded2radar();
        upgraded2claw();
        diverspawnonupdate();
        treasurespawnonupdate();
    }
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        po = GameObject.Find("popo");
        penny = GameObject.Find("PennyModel");
        toplightbulb = GameObject.Find("TopLightBulb");
        rearleftbulb = GameObject.Find("LeftLightBulb");
        rearrightbulb = GameObject.Find("RightLightBulb");
        radar = GameObject.Find("Radar");
        radarpic = GameObject.Find("radarpic");
        theClaw = GameObject.Find("ArmPivotPoint");
        diverSpawnScript = GameObject.Find("DiverSpawnPoints");
    }
}
