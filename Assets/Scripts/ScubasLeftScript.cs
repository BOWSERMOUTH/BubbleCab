using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScubasLeftScript : MonoBehaviour
{
    public static Text howManyLeft;
    int diver;

    void Start()
    {
        howManyLeft = gameObject.GetComponent<Text>();

    }
    void Update()
    {
        diver = GameObject.FindGameObjectsWithTag("Diver").Length;
        howManyLeft.text = "Divers left: " + diver.ToString();
    }
}