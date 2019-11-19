using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopupText : MonoBehaviour
{
    public Submarine submarine;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "+ " + Submarine.score.ToString();
    }
}
