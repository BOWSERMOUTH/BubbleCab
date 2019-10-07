using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Submarine submarine;
    public Text scoreText;
    public GameObject popupscore;

	void Start ()
    {
        scoreText = gameObject.GetComponent<Text>();
	}
    public void makePopUpOnScore()
    {
        var go = Instantiate(popupscore) as GameObject;
        go.transform.parent = scoreText.transform;
        go.transform.position = scoreText.transform.position;
    }

	void Update ()
    {
        scoreText.text = "Score: " + Submarine.score.ToString();
    }
    
}
