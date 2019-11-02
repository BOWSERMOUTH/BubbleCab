using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject ui;
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
    public GameObject Pause;
    public GameObject WinScreen;

    // SPAWN DIVER LOGIC
    public Vector3[] spawnPoints;
    public Vector3[] treasureSpawnPoints;
    public int maxDivers = 4;
    public int maxTreasures = 3;
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

    // LEVEL LOGIC
    public int level;
    public bool caveExplorable = false;
    public bool levelwinbool = false;
    public bool paused = false;
    public TimerScript timer;
    public int diversleft;

    void Start ()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        po = GameObject.Find("popo");
        penny = GameObject.Find("PennyModel");
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
    void Update()
    {
        whosplaying();
        PauseGame();
        upgraded2radar();
        upgraded2claw();
        diverspawnonupdate();
        treasurespawnonupdate();
        CheckForDivers();
    }
    private void CheckForDivers()
    {
        diversleft = GameObject.FindGameObjectsWithTag("Diver").Length;
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
        else if (upgradedtoradar == false)
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
        }
        else if (upgradedtoclaw == false)
        {
            theClaw.SetActive(false);
        }
    }
    public void diverspawnonupdate()
    {
        if (maxDivers < 1)
        {
            return;
        }
        else
        {
            spawnDiverIntro();
        }
    }
    public void treasurespawnonupdate()
    {
        if (maxTreasures < 1)
        {
            return;
        }
        else
        {
            spawnTreasureIntro();
        }
    }
    public void LevelLogic()
    {
        if (level == 1)
        {
            maxDivers = 1;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 2)
        {
            maxDivers = 2;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 3)
        {
            maxDivers = 5;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 4)
        {
            maxDivers = 6;
            maxTreasures = 3;
            caveExplorable = true;
            timer.timeLeft = 120f;
        }
        else if (level == 5)
        {
            maxDivers = 7;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 6)
        {
            maxDivers = 8;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 7)
        {
            maxDivers = 8;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 8)
        {
            maxDivers = 8;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
    }
    public void BeatingLevel()
    {
            ResettingMap();
            level = level + 1;
            SpawnWinScreen();
            LevelLogic();
    }
    public void ResettingMap()
    {
        GameObject[] divers = GameObject.FindGameObjectsWithTag("Diver");
        GameObject[] treasures = GameObject.FindGameObjectsWithTag("Treasure");
        for (var i = 0; i < divers.Length; i ++)
        {
            Destroy(divers[i]);
        }
        for (var o = 0; o < treasures.Length; o ++)
        {
            Destroy(treasures[o]);
        }
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Pause.SetActive(true);
        }
    }
    public void ResetGameManager()
    {
        maxDivers = 0;
        maxTreasures = 0;
        upgradedtolights = false;
        upgradedtoclaw = false;
        upgradedtoradar = false;
        upgradedtoboost = false;
        level = 0;
        caveExplorable = false;
    }
    public void SpawnWinScreen()
    {
        Instantiate(WinScreen, ui.transform);
    }
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            level = 1;
            ui = GameObject.Find("UI");
            Pause = GameObject.Find("PauseScreen");
            po = GameObject.Find("popo");
            penny = GameObject.Find("PennyModel");
            toplightbulb = GameObject.Find("TopLightBulb");
            rearleftbulb = GameObject.Find("LeftLightBulb");
            rearrightbulb = GameObject.Find("RightLightBulb");
            radar = GameObject.Find("Radar");
            radarpic = GameObject.Find("radarpic");
            upgradedtoradar = false;
            theClaw = GameObject.Find("ArmPivotPoint");
            upgradedtoclaw = false;
            timer = GameObject.FindObjectOfType<TimerScript>();
            LevelLogic();
        }
    }
}
