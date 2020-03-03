using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    //DEBUG
    public bool DebugBool;
    public GameObject DebugMode;
    // STATS
    public float timePlayed;
    public float diversSaved;
    //GAME LOGIC
    public string chosencharacter;
    public Vector3 playerPosition;
    public GameObject ui;
    public static GameManager instance = null;
    public int divervalue = 200;
    public int treasurevalue = 100;
    public int currentvalueforpopup;

    //OBJECT REFERENCES
    public EventSystem eventSystem;
    public GameObject resumeGameButton;
    public GameObject submarine = null;
    public GameObject po;
    public GameObject penny;
    public GameObject crumbs;
    private GameObject polab;
    private GameObject pennylab;
    private GameObject crumbslab;
    private GameObject toplightbulb;
    private GameObject rearrightbulb;
    private GameObject rearleftbulb;
    public GameObject radar;
    public GameObject radarpic;
    public GameObject theClaw;
    public GameObject Pause;
    public GameObject Panel;
    public GameObject WinScreen;
    public GameObject WinScreenPlaceHolder;
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
    public int subUpgradedCapacity = 1;
    public int playerlives = 3;

    // LEVEL LOGIC
    public FishTank fishtank;
    public int level = 1;
    public bool levelwinbool = false;
    public bool paused = false;
    public TimerScript timer;
    public int diversleft;
    
    void OnEnable ()
    {
        eventSystem = UnityEngine.EventSystems.EventSystem.current;
        level = 1;
        po = GameObject.Find("popo");
        penny = GameObject.Find("PennyModel");
        crumbs = GameObject.Find("Crumbs");
        SceneManager.sceneLoaded += OnSceneLoaded;
        // DEBUG MODE
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
        if (level >= 4)
        {
            spawnPoints.Add(new Vector3(29.88f, -24.22f, -0.09f));
            spawnPoints.Add(new Vector3(8.97f, -23.98f, -0.09f));
            spawnPoints.Add(new Vector3(-11.41f, -24.92f, -0.09f));
            spawnPoints.Add(new Vector3(-21.11f, -20.2f, -0.09f));
        }
    }
    public void SetTreasurePoints()
    {
        treasureSpawnPointsList.Clear();
        treasureSpawnPointsList.Add(new Vector3(6.55f, -9.45f, -0.09f));
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
        PauseGame();
        upgraded2radar();
        upgraded2claw();
        TurnOnDebug();
        print("my first selected is on " + eventSystem.firstSelectedGameObject);
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
        if (chosencharacter == "Popo")
        {
            po.SetActive(true);
            penny.SetActive(false);
            crumbs.SetActive(false);
            pennylab.SetActive(true);
            polab.SetActive(false);
            crumbslab.SetActive(false);
        }
        else if (chosencharacter == "Penny")
        {
            po.SetActive(false);
            penny.SetActive(true);
            crumbs.SetActive(false);
            pennylab.SetActive(false);
            polab.SetActive(false);
            crumbslab.SetActive(true);
        }
        else if (chosencharacter == "Crumbs")
        {
            po.SetActive(false);
            penny.SetActive(false);
            crumbs.SetActive(true);
            pennylab.SetActive(false);
            polab.SetActive(true);
            crumbslab.SetActive(false);
        }
    }
    public void ChosenCharacter()
    {
        chosencharacter = null;
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
            maxDivers = 2;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            spawnDivers();
            spawnTreasure();

        }
        else if (level == 2)
        {
            maxDivers = 3;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            spawnDivers();
            spawnTreasure();
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
            maxDivers = 4;
            maxTreasures = 3;
            Destroy(GameObject.Find("CutSceneRockLeftG"));
            Destroy(GameObject.Find("CutSceneRockRightG"));
            Destroy(GameObject.Find("FigureheadG"));
            Instantiate(CaveCutScene);
            StartCoroutine(WaitingForScript());
        }
        else if (level == 5)
        {
            SceneManager.LoadScene(2);
        }
        else if (level == 6)
        {
            maxDivers = 5;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            spawnDivers();
            spawnTreasure();
        }
        else if (level == 7)
        {
            maxDivers = 6;
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
        else if (level == 9)
        {
            SceneManager.LoadScene(3);
        }
        fishtank.ChangeFishOnLevel();
    }

    public void BeatingLevel()
    {
        if (level <= 8)
        {
            StartCoroutine(DimMusicDuringWin());
        }
        playerPosition = submarine.transform.position;
        ResettingMap();
        level += 1;
        SpawnWinScreen();
        LevelLogic();
    }
    public void CurrentLevel()
    {
        playerlives = playerlives - 1;
        submarine.GetComponent<Submarine>().ClearCollectedDivers();
        currentDivers.Clear();
        StartCoroutine(DimMusicDuringWin());
        ResettingMap();
        SpawnWinScreen();
        LevelLogic();
        subCarryingCapacity = subUpgradedCapacity;
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
        if (Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf == false && Panel.activeSelf == false)
        {

            Pause.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf == true)
        {
            Pause.SetActive(false);
        }
    }
    public void C_PauseGame()
    {
        if (Pause.activeSelf == false && Panel.activeSelf == false)
        {
            Pause.SetActive(true);
            eventSystem.SetSelectedGameObject(resumeGameButton);
        }
        else if (Pause.activeSelf == true)
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
        currentDivers.Clear();
        currentTreasures.Clear();
        playerlives = 3;
    }

    public void SpawnWinScreen()
    {
        Instantiate(WinScreen, WinScreenPlaceHolder.transform);
    }

    public void TurnOnDebug()
    {
        if (Input.GetKey(KeyCode.F12))
        {
            if (Input.GetKeyDown(KeyCode.D) && (DebugMode.activeSelf == false))
            {
                DebugMode.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.D) && (DebugMode.activeSelf == true))
            {
                DebugMode.SetActive(false);
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
    public void ObjectReferences()
    {
        resumeGameButton = GameObject.Find("ResumeGameButton");
        eventSystem = UnityEngine.EventSystems.EventSystem.current;
        submarine = GameObject.Find("Submarine");
        ui = GameObject.Find("UI");
        WinScreenPlaceHolder = GameObject.Find("WinScreen");
        Pause = GameObject.Find("PauseScreen");
        Panel = GameObject.Find("Panel");
        Panel.SetActive(false);
        po = GameObject.Find("popo");
        penny = GameObject.Find("PennyModel");
        crumbs = GameObject.Find("Crumbs");
        polab = GameObject.Find("PopoLab");
        pennylab = GameObject.Find("PennyLab");
        crumbslab = GameObject.Find("CrumbsLab");
        toplightbulb = GameObject.Find("TopLightBulb");
        rearleftbulb = GameObject.Find("LeftLightBulb");
        rearrightbulb = GameObject.Find("RightLightBulb");
        radar = GameObject.Find("Radar");
        radarpic = GameObject.Find("radarpic");
        theClaw = GameObject.Find("ArmPivotPoint");
        timer = GameObject.FindObjectOfType<TimerScript>();
        music = Camera.main.GetComponent<AudioSource>();
        fishtank = GameObject.Find("FishTank").GetComponent<FishTank>();
    }
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            eventSystem = UnityEngine.EventSystems.EventSystem.current;
            po = GameObject.Find("popo");
            penny = GameObject.Find("PennyModel");
            crumbs = GameObject.Find("Crumbs");
            penny.SetActive(false);
            crumbs.SetActive(false);
        }
        else if (scene.buildIndex == 1)
        {
            ObjectReferences();
            LevelLogic();
            whosplaying();
        }
        else if (scene.buildIndex == 2)
        {
            ObjectReferences();
            submarine.transform.position = playerPosition;
            whosplaying();
            ResettingMap();
            maxDivers = 5;
            maxTreasures = 3;
            timer.timeLeft = 120f;
            SetDiverSpawnPoints();
            SetTreasurePoints();
            spawnDivers();
            spawnTreasure();
            SpawnWinScreen();
            StartCoroutine(DimMusicDuringWin());
        }
    }
}
