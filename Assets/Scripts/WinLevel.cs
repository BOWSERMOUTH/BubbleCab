﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLevel : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (GameManager.instance.level == 8)
        {
            text.text = "FINAL LEVEL";
        }
        else text.text = "LEVEL " + GameManager.instance.level;
    }
}
