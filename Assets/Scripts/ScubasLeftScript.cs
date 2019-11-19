using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScubasLeftScript : MonoBehaviour
{
    public static Text howManyLeft;
    public static int diver;

    void Start()
    {
        howManyLeft = gameObject.GetComponent<Text>();

    }

    void Update()
    {
        diver = GameObject.FindGameObjectsWithTag("Diver").Length;
        howManyLeft.text = "DIVERS LEFT: " + diver.ToString();
    }
}