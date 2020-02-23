using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTank : MonoBehaviour
{
    public GameObject bluefish;
    public GameObject yellowfish;
    public GameObject redfish;
    public GameObject silverfish;
    public GameObject whitefish;
    public GameObject clownfish;
    public GameObject jellyfish;
    public GameObject jellyfishnight;
    //public GameObject jellyfish;
    //public GameObject clownfish;

    // Start is called before the first frame update
    void Start()
    {
        ChangeFishOnLevel();
    }
    public void ChangeFishOnLevel()
    {
        if (GameManager.instance.level == 1)
        {
            clownfish.SetActive(true);
        }
        else if (GameManager.instance.level == 2)
        {
            bluefish.SetActive(true);
        }
        else if (GameManager.instance.level == 3)
        {
            redfish.SetActive(true);
        }
        else if (GameManager.instance.level == 4)
        {
            jellyfish.SetActive(true);
        }
        else if (GameManager.instance.level == 5)
        {
            jellyfishnight.SetActive(true);
            jellyfish.SetActive(true);
        }

    }
}
