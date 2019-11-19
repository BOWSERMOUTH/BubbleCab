using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject penny;
    public GameObject po;
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
        gamemanager.charactertoggle = true;

    }

    public void switchToPenny()
    {
        audio.PlayOneShot(clickNoise);
        po.SetActive(false);
        penny.SetActive(true);
        gamemanager.charactertoggle = false;
    }
}
