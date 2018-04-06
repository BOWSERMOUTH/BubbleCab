using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Submarine submarine;
    public Text scoreText;

	void Start ()
    {
        scoreText = gameObject.GetComponent<Text>();
	}
	

	void Update ()
    {
        scoreText.text = "Score: " + Submarine.score.ToString();
    }
}
