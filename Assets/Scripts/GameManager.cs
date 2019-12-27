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
    public int divervalue = 200;
    public int treasurevalue = 100;
    public int currentvalueforpopup;

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
    public AudioSource music;

    // SPAWN DIVER LOGIC
    public List<Vector3> spawnPoints;
    public List<GameObject> currentDivers;
    public List<Vector3> treasureSpawnPointsList;
    public List<GameObject> currentTreasures;
    public int maxDivers = 4;
    public int maxTreasures = 3;
    public GameObject diver;
    public GameObject treasurechest;

    // ABILITY UPGRADES
    public bool upgradedtolights;
    public bool upgradedtoradar;
    public bool upgradedtoboost;
    public bool upgradedtoclaw;

    // SCORE / CAPACITY / LIVES
    public int score = 0;
    public int subHull = 3;
    public int subHullLimit = 3;
    public int subCarryingCapacity = 1;
    public int playerlives = 3;

    // LEVEL LOGIC
    public int level = 1;
    public bool levelwinbool = false;
    public bool paused = false;
    public TimerScript timer;
    public int diversleft;
    public bool charactertoggle;

    void Start ()
    {
        level = 1;
        SceneManager.sceneLoaded += OnSceneLoaded;
        po = GameObject.Find("popo");
        penny = GameObject.Find("PennyModel");
        //FIXME: Make this dependent on when in debug mode
        //DEBUG:
        //DebugSetDiverSpawnPoints();
        SetDiverSpawnPoints();
        SetTreasurePoints();
    }
    public void SetDiverSpawnPoints()
    {
        //TODO: We can use the spawnpoints created in the editor
        //rather than clear them and set them in code. 
        spawnPoints.Clear();
        spawnPoints.Add(new Vector3(-9.47f, -7.67f, -0.09f));
        spawnPoints.Add(new Vector3(-24.64f, -7.67f, -0.09f));
        spawnPoints.Add(new Vector3(-55.2f, -10.23f, -0.09f));
        spawnPoints.Add(new Vector3(1.45f, -7.45f, -0.09f));
        spawnPoints.Add(new Vector3(27.48f, -10.42f, -0.09f));
        spawnPoints.Add(new Vector3(59.72f, -11.65f, -0.09f));
        spawnPoints.Add(new Vector3(79.61f, 5.92f, -0.09f));
        spawnPoints.Add(new Vector3(79.61f, -11.67f, -0.09f));
        spawnPoints.Add(new Vector3(-2.97f, 5.81f, -0.09f));
        spawnPoints.Add(new Vector3(23.74f, -6.68f, -0.09f));
        spawnPoints.Add(new Vector3(59.44f, -1.08f, -0.09f));
        spawnPoints.Add(new Vector3(46.3f, -11.26f, -0.09f));
        spawnPoints.Add(new Vector3(37.16f, -13.11f, -0.09f));
        spawnPoints.Add(new Vector3(-35.86f, 6.62f, -0.09f));
        spawnPoints.Add(new Vector3(-62.84f, -10.09f, -0.09f));
    }
    public void SetTreasurePoints()
    {
        treasureSpawnPointsList.Clear();
        treasureSpawnPointsList.Add(new Vector3(7.98f, -10.01f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(23.07f, -7.55f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(27.73f, -12.54f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(36.7f, -14.36f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(57.89f, -13.58f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(66.22f, -12.71f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(53.44f, 5f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(79.53f, -14.25f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(21.73f, 4.45f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(-3.41f, 4.63f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(-40.76f,-13.87f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(-54.42f, -12.91f, -0.09f));
        treasureSpawnPointsList.Add(new Vector3(-37.89f, 8.63f, -0.09f));
    }

    public void DebugSetDiverSpawnPoints()
    {
        spawnPoints.Clear();
        spawnPoints.Add(new Vector3(-26f, 15f, -0.09f));
        spawnPoints.Add(new Vector3(-24f, 15f, -0.09f));
        spawnPoints.Add(new Vector3(-22f, 15f, -0.09f));
        spawnPoints.Add(new Vector3(-20f, 15f, -0.09f));
        spawnPoints.Add(new Vector3(-18f, 15f, -0.09f));
        spawnPoints.Add(new Vector3(-16f, 15f, -0.09f));
        spawnPoints.Add(new Vector3(-14f, 15f, -0.09f));
        spawnPoints.Add(new Vector3(-12f, 15f, -0.09f));
        spawnPoints.Add(new Vector3(-10f, 15f, -0.09f));
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
        CheckForDebugMode();
        TurnOnDebug();
    }

    // Tells divers to spawn in random locations
    private void spawnDivers()
    {
        //Create a list called RemainingSpawnPoints and set it to whatever you've set SpawnPoints locations to.
        List<Vector3> remainingSpawnPoints = spawnPoints;

        //As long as currentdivers list is less than the max divers count.. do the following.
        while (currentDivers.Count < maxDivers)
        {
            //find a random spawn point from remaining spawn points
            Vector3 selectedSpawnPoint = remainingSpawnPoints[Random.Range(0, remainingSpawnPoints.Count)];

            //create a diver
            GameObject selectedDiver = Instantiate(diver, selectedSpawnPoint, Quaternion.Euler(0, -90, 0));

            //add selected diver to currentDivers
            currentDivers.Add(selectedDiver);

            //remove chosen spawn point from list of possible spawns
            remainingSpawnPoints.Remove(selectedSpawnPoint);
        }
    }

    private void spawnTreasure()
    {
        List<Vector3> remainingSpawnPoints = treasureSpawnPointsList;
        while (currentTreasures.Count < maxTreasures)
        {
            Vector3 selectedSpawnPoint = remainingSpawnPoints[Random.Range(0, remainingSpawnPoints.Count)];
            GameObject selectedTreasure = Instantiate(treasurechest, selectedSpawnPoint, Quaternion.Euler(-90, -90, 0));
            currentTreasures.Add(selectedTreasure);
            remainingSpawnPoints.Remove(selectedSpawnPoint);
        }
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

// Level Logic - Adjust how many divers / treasures spawn per level / Time limit per level
    public void LevelLogic()
    {
        if (level == 1)
        {
            maxDivers = 1;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            spawnDivers();
            spawnTreasure();
        }
        else if (level == 2)
        {
            SceneManager.LoadScene(2);
        }
        else if (level == 3)
        {
            maxDivers = 3;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            spawnDivers();
            spawnTreasure();
        }
        else if (level == 4)
        {
            spawnPoints.Add(new Vector3(29.88f, -24.22f, -0.09f));
            spawnPoints.Add(new Vector3(8.97f, -23.98f, -0.09f));
            spawnPoints.Add(new Vector3(-11.41f, -24.92f, -0.09f));
            spawnPoints.Add(new Vector3(-21.11f, -20.2f, -0.09f));
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
            spawnDivers();
            spawnTreasure();
        }
        else if (level == 6)
        {
            maxDivers = 8;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            spawnDivers();
            spawnTreasure();
        }
        else if (level == 7)
        {
            maxDivers = 8;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            spawnDivers();
            spawnTreasure();
        }
        else if (level == 8)
        {
            maxDivers = 8;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            spawnDivers();
            spawnTreasure();
        }
    }

    public void BeatingLevel()
    {
        StartCoroutine(DimMusicDuringWin());
        ResettingMap();
        level += 1;
        SpawnWinScreen();
        LevelLogic();
    }
    public void CurrentLevel()
    {
        playerlives = playerlives - 1;
        StartCoroutine(DimMusicDuringWin());
        ResettingMap();
        SpawnWinScreen();
        LevelLogic();
        subHull = subHullLimit;

        if (playerlives == 0)
        {
            ResetGameManager();
            SceneManager.LoadScene(0);
        }
    }
    // Mutes the game music during the win music, then unmutes after it's finished. 
    IEnumerator DimMusicDuringWin()
    {
        music.volume = 0.02f;
        print("ive dimmed volume in script");
        yield return new WaitForSeconds(4f);
        music.volume = 0.386f;
    }
    // Pauses the game and removes the UI during the CaveCutScene, then resets the timer. 
    IEnumerator WaitingForScript()
    {
        ui.SetActive(false);
        yield return new WaitForSeconds(23.3f);
        Destroy(GameObject.Find("CaveCutScene(Clone)"));
        ui.SetActive(true);
        timer.timeLeft = 120f;
        spawnDivers();
        spawnTreasure();
    }

    // clears map of all randomly spawned objects and rescued divers
    public void ResettingMap()
    {
        GameObject[] savedDivers = GameObject.FindGameObjectsWithTag("DiverSaved");
        GameObject[] divers = GameObject.FindGameObjectsWithTag("Diver");
        GameObject[] treasures = GameObject.FindGameObjectsWithTag("Treasure");
        for (var i = 0; i < divers.Length; i ++)
        {
            Destroy(divers[i]);
            // Removes CurrentTreasures from the list, so it can repopulate based on line 176
            currentDivers.Clear();
        }
        for (var o = 0; o < treasures.Length; o ++)
        {
            Destroy(treasures[o]);
            // Removes CurrentDivers from the list, so it can repopulate based on line 176
            currentTreasures.Clear();
        }
        for (var d = 0; d < savedDivers.Length; d ++)
        {
            Destroy(savedDivers[d]);
        }
        SetDiverSpawnPoints();
        SetTreasurePoints();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf == false)
        {
            Pause.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf == true)
        {
            Pause.SetActive(false);
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
        level = 1;
        score = 0;
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
    void LevelTwoLoad()
    {
        ResettingMap();
        maxDivers = 5;
        maxTreasures = 3;
        timer.timeLeft = 120f;
        SetDiverSpawnPoints();
        SetTreasurePoints();
        spawnDivers();
        spawnTreasure();
    }
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
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
            music = Camera.main.GetComponent<AudioSource>();
        }
        if (scene.buildIndex == 1)
        {
            LevelLogic();
        }
        if (scene.buildIndex == 2)
        {
            ResettingMap();
            maxDivers = 5;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            SetDiverSpawnPoints();
            SetTreasurePoints();
            spawnDivers();
            spawnTreasure();
            //Invoke("LevelTwoLoad", 1.5f);
        }
    }
}
