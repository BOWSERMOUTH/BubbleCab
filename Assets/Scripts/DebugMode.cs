using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebugMode : MonoBehaviour
{
    public bool upgradetoclawD;
    public bool upgradetoradarD;
    public bool upgradetoboostD;
    public bool upgradetohull;
    public bool upgradetolights;

    public void addhundredpoints()
    {
        GameManager.instance.score = GameManager.instance.score + 100;
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
        if (GameManager.instance.subHullLimit <= 5)
        {
            GameManager.instance.subHullLimit += 1;
        }
        else
        {
            return;
        }
    }

    public void addrepair()
    {
        GameManager.instance.subHull += 1;
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
