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
    public int maxDivers = 3;
    public GameObject diver;
    public List<int> usedIds;
    int random;

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
            random = Random.Range(0, spawnPoints.Length);
        }
        while (usedIds.IndexOf(random) != -1);

        usedIds.Add(random);
        Instantiate(diver, spawnPoints[random], Quaternion.Euler(0, -90, 0));
        maxDivers = maxDivers - 1;
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
    // Update is called once per frame
    void Update () {
        SceneManager.sceneLoaded += OnSceneLoaded;
        whosplaying();
        upgraded2radar();
        upgraded2claw();
        diverspawnonupdate();
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
