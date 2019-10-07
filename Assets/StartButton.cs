using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{


    public AudioSource audio;
    public AudioClip starthighlight;
    public AudioClip startclick;

    public void HoverSound()
    {
        audio.PlayOneShot(starthighlight);
    }
    public void ClickSound()
    {
        audio.PlayOneShot(startclick);
    }
}


