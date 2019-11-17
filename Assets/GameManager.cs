using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //DEBUG
    public bool DebugBool;
    public GameObject DebugMode;
    //GAME LOGIC
    public GameObject ui;
    public static GameManager instance = null;
    
    //OBJECT REFERENCES
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
    public GameObject CaveCutScene;

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
    public bool levelwinbool = false;
    public bool paused = false;
    public TimerScript timer;
    public int diversleft;
    public bool charactertoggle;

    void Start ()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        po = GameObject.Find("popo");
        penny = GameObject.Find("PennyModel");
        spawnPoints = new Vector3[15];
        SetSpawnPoints();


    }
    public void SetSpawnPoints()
    {
        spawnPoints[0] = new Vector3(-9.47f, -7.67f, -0.09f);
        spawnPoints[1] = new Vector3(-24.64f, -7.67f, -0.09f);
        spawnPoints[2] = new Vector3(-55.2f, -10.23f, -0.09f);
        spawnPoints[3] = new Vector3(1.45f, -7.45f, -0.09f);
        spawnPoints[4] = new Vector3(27.48f, -10.42f, -0.09f);
        spawnPoints[5] = new Vector3(59.72f, -11.65f, -0.09f);
        spawnPoints[6] = new Vector3(79.61f, 5.92f, -0.09f);
        spawnPoints[7] = new Vector3(79.61f, -11.67f, -0.09f);
        spawnPoints[8] = new Vector3(-2.97f, 5.81f, -0.09f);
        spawnPoints[9] = new Vector3(23.74f, -6.68f, -0.09f);
        spawnPoints[10] = new Vector3(59.44f, -1.08f, -0.09f);
        spawnPoints[11] = new Vector3(46.3f, -11.26f, -0.09f);
        spawnPoints[12] = new Vector3(37.16f, -13.11f, -0.09f);
        spawnPoints[13] = new Vector3(-35.86f, 6.62f, -0.09f);
        spawnPoints[14] = new Vector3(-62.84f, -10.09f, -0.09f);
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
        CheckForDebugMode();
        TurnOnDebug();
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
            TheStore.instance.upgrade2radar.interactable = false;
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
            maxDivers = 3;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 2)
        {
            maxDivers = 3;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 3)
        {
            maxDivers = 1;
            maxTreasures = 3;
            timer.timeLeft = 120f;
        }
        else if (level == 4)
        {
            spawnPoints = new Vector3[19];
            SetSpawnPoints();
            spawnPoints[15] = new Vector3(29.88f, -29.51f, -0.09f);
            spawnPoints[16] = new Vector3(8.97f, -23.98f, -0.09f);
            spawnPoints[17] = new Vector3(-11.41f, -24.92f, -0.09f);
            spawnPoints[18] = new Vector3(-21.11f, -20.2f, -0.09f);
            maxDivers = 6;
            maxTreasures = 3;
            Destroy(GameObject.Find("CutSceneRockLeftG"));
            Destroy(GameObject.Find("CutSceneRockRightG"));
            Destroy(GameObject.Find("FigureheadG"));
            Instantiate(CaveCutScene);
            StartCoroutine(WaitingForScript());
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
    IEnumerator WaitingForScript()
    {
        ui.SetActive(false);
        yield return new WaitForSeconds(23.3f);
        Destroy(GameObject.Find("CaveCutScene(Clone)"));
        ui.SetActive(true);
        timer.timeLeft = 120f;
    }
    public void ResettingMap()
    {
        GameObject[] savedDivers = GameObject.FindGameObjectsWithTag("Friendly");
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
        for (var d = 0; d < savedDivers.Length; d ++)
        {
            Destroy(savedDivers[d]);
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
    }
    public void SpawnWinScreen()
    {
        Instantiate(WinScreen, ui.transform);
    }
    public void TurnOnDebug()
    {
        if (Input.GetKey(KeyCode.F12))
        {
            if (Input.GetKey(KeyCode.D))
            {
                DebugBool = true;
                CheckForDebugMode();

            }
        }
    }
    public void CheckForDebugMode()
    {
        if (DebugBool == true)
        {
            DebugMode.SetActive(true);
        }
        else if (DebugBool == false)
        {
            DebugMode.SetActive(false);
        }
    }
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            level = 3;
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
