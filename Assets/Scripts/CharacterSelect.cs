using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject penny;
    public GameObject po;
    public GameObject crumbs;
    public GameManager gamemanager;
    public AudioClip clickNoise;
    private AudioSource audio;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void switchToPo()
    {
        audio.PlayOneShot(clickNoise);
        po.SetActive(true);
        penny.SetActive(false);
        crumbs.SetActive(false);
        gamemanager.chosencharacter = "Popo";

    }

    public void switchToPenny()
    {
        audio.PlayOneShot(clickNoise);
        po.SetActive(false);
        penny.SetActive(true);
        crumbs.SetActive(false);
        gamemanager.chosencharacter = "Penny";
    }
    public void switchToCrumbs()
    {
        audio.PlayOneShot(clickNoise);
        po.SetActive(false);
        penny.SetActive(false);
        crumbs.SetActive(true);
        gamemanager.chosencharacter = "Crumbs";
    }
}
