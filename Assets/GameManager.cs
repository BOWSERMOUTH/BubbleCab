using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool charactertoggle;
    private GameObject po;
    private GameObject penny;
    private GameObject toplightbulb;
    private GameObject rearrightbulb;
    private GameObject rearleftbulb;

    // ABILITY UPGRADES
    public bool upgradedtolights;




    void Start ()
    {
    }
    // Player
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
    // Update is called once per frame
    void Update () {
        SceneManager.sceneLoaded += OnSceneLoaded;
        whosplaying();
    }
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        po = GameObject.Find("popo");
        penny = GameObject.Find("PennyModel");
        toplightbulb = GameObject.Find("TopLightBulb");
        rearleftbulb = GameObject.Find("LeftLightBulb");
        rearrightbulb = GameObject.Find("RightLightBulb");
    }
}
