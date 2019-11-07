using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour
{
    public ScoreScript scorescript;
    public bool upgradetoclawD;
    public bool upgradetoradarD;
    public bool upgradetoboostD;
    public bool upgradetohull;
    public bool upgradetolights;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gamemanager = GameManager.instance;
        Submarine submarine = Submarine.instance;

    }
    public void addhundredpoints()
    {
        scorescript = ScoreScript.instance;
        Submarine.score = Submarine.score + 100;
        scorescript.makePopUpOnScore();
    }
    public void addradar()
    {
        GameManager.instance.upgradedtoradar = true;
    }
    public void addboost()
    {
        GameManager.instance.upgradedtoboost = true;
    }
    public void addclaw()
    {
        GameManager.instance.upgradedtoclaw = true;
    }
    public void addlights()
    {
        GameManager.instance.upgradedtolights = true;
    }
    public void addhull()
    {
        if (Submarine.hulllimit <= 5)
        {
            Submarine.hulllimit = Submarine.hulllimit + 1;
        }
        else
        {
            return;
        }
    }
    public void addrepair()
    {
        Submarine.hull = Submarine.hull + 1;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
