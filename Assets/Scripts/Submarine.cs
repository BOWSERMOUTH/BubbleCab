﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Submarine : MonoBehaviour {

    public List<GameObject> collectedDivers;
    Rigidbody rigidBody;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public ScoreScript scoreboard;
    
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip grabbedScuba;
    [SerializeField] AudioClip flashlight;
    [SerializeField] AudioClip hurt;
    // CONTROLS
    public float rotationThrust = 150f;
    [SerializeField] float mainThrust = 1f;
    [SerializeField] float levelLoadDelay = 2f;

    enum State {  Alive, Dying, Transcending }
    State state = State.Alive;
    public TimerScript timer;
    //PIECES THAT FALL OFF WHEN DEAD
    public GameObject dome;
    public GameObject popo;
    public GameObject penny;
    public GameObject crumbs;
    private GameObject rightFloaty;
    private GameObject leftFloaty;
    
    //DAMAGE LOGIC
    public bool invincibility;
    public bool bubbleBoost;

    //CARRYING LOGIC
    public bool isCarrying = false;
    //public int carryingCapacity = 1;
    public int cargoCount = 0;

    //LIGHT CONTROLS
    public bool lightControl;
    public GameObject topLight;
    public GameObject leftLight;
    public GameObject rightLight;

    // PHYSICS
    public bool engineOff;
    public Camera maincamera;
    AudioHighPassFilter mufflesound;

    //SCUBA MAN UPRIGHT
    private Quaternion upRight = Quaternion.Euler(-50, -90, 0);
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        mufflesound = maincamera.GetComponent<AudioHighPassFilter>();
        rightFloaty = GameObject.Find("RightFloaty");
        leftFloaty = GameObject.Find("LeftFloaty");
    }

    public void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust);
        // So audio doesn't layer
        if (!audioSource1.isPlaying)
        {
            audioSource1.PlayOneShot(mainEngine);
        }
    }

    void Update ()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
            lightsOnOff();
        }
	}

    // CONTROLS LIGHTS WITH F
    private void lightsOnOff()
    {
        if (Input.GetKeyDown(KeyCode.F) && GameManager.instance.upgradedtolights)
        {
            lightControl = !lightControl;
            audioSource2.PlayOneShot(flashlight);
        }

        if (lightControl == true)
        {
            topLight.gameObject.SetActive(true);
            rightLight.gameObject.SetActive(true);
            leftLight.gameObject.SetActive(true);
        }

        if (lightControl == false)
        {
            topLight.gameObject.SetActive(false);
            rightLight.gameObject.SetActive(false);
            leftLight.gameObject.SetActive(false);
        }
    }
    // Controls
    private void RespondToThrustInput()
    {
        if (engineOff == true)
        {
            mainThrust = 0f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && engineOff == false && GameManager.instance.upgradedtoboost == true)
        {
            mainThrust = 20f;
            audioSource1.pitch = 1.6f;
        }
        else if (engineOff == false)
        {
            mainThrust = 10f;
            audioSource1.pitch = .6f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            ApplyThrust();
        }
        else
        {
            audioSource1.Stop();
            audioSource1.pitch = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddRelativeForce(Vector3.down * mainThrust);
        }
    }
    // THRUST STRENGTH
    private void RespondToRotateInput()
    {
        // Freezing rotation as soon as we rotate
        rigidBody.freezeRotation = true;
        // Turning Power
        float rotationThisFrame = rotationThrust * Time.deltaTime;

        // Rotating Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        // Rotating Right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationThisFrame);
        }
        // Allowing rotation to resume after rotating
        //rigidBody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If we're not alive, return
        if (state != State.Alive)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // Do Nothing
                break;
            case "DiverFriendly":
                break;
            case "Surface":
                break;
            case "Grippable":
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                if (invincibility == false)
                {
                    invincibility = true;
                    audioSource2.PlayOneShot(hurt);
                    GameManager.instance.subHull -= 1;
                    StartCoroutine(HurtFlicker());
                    Invoke("TurnInvincibilityOff", 2f);
                }
                if (GameManager.instance.subHull < 1)
                {
                    TimerScript time = GameObject.Find("Timer").GetComponent<TimerScript>();
                    time.TimerEnd();
                }
                break;
        }
    }
    private void TurnInvincibilityOff()
    {
        invincibility = false;
    }
    // Makes your ship flicker when injured for the duration of the i-frames
    IEnumerator HurtFlicker()
    {
        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(.075f);
            dome.GetComponent<Renderer>().enabled = false;
            leftFloaty.GetComponent<Renderer>().enabled = false;
            rightFloaty.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(.075f);
            dome.GetComponent<Renderer>().enabled = true;
            leftFloaty.GetComponent<Renderer>().enabled = true;
            rightFloaty.GetComponent<Renderer>().enabled = true;
        }
    }

    // COLLIDING WITH SCUBA DIVER
    private void OnTriggerEnter(Collider collidedwith)
    {
        //FIXME: instead of adding to carrying capacity, have a list for divers held.
        if (collidedwith.gameObject.tag == "Diver" && GameManager.instance.subCarryingCapacity >= 1f)
        {
            // Pick Up Diver
            collectedDivers.Add(collidedwith.gameObject);
            collidedwith.transform.parent = dome.transform;
            collidedwith.gameObject.transform.position = dome.transform.position + dome.transform.right * .3f;
            collidedwith.transform.rotation = Quaternion.identity;
            collidedwith.enabled = false;
            isCarrying = true;
            GameManager.instance.subCarryingCapacity -= 1;
            cargoCount += 1;
            audioSource1.PlayOneShot(grabbedScuba, 1);
            //FIXME: remove the diver from currentDivers when cashing in points
            //remove diver from playing field
            GameManager.instance.currentDivers.Remove(collidedwith.gameObject);
        }
        else if (collidedwith.gameObject.tag == "Treasure")
        {
            GameManager.instance.score = GameManager.instance.score + GameManager.instance.treasurevalue;
            GameManager.instance.currentvalueforpopup = GameManager.instance.treasurevalue;
            scoreboard.makePopUpOnScore();
            //remove treasure from playing field
            GameManager.instance.currentTreasures.Remove(collidedwith.gameObject);
        }
        else if (collidedwith.gameObject.tag == "Surface")
        {
                mufflesound.enabled = true;
                rigidBody.useGravity = true;
                rigidBody.mass = 3;
                rigidBody.drag = 1;
                engineOff = true;
                rigidBody.freezeRotation = false;
                ScoringPoint();
        }
    }
    // SCORING A POINT WITH A SCUBA GUY
    private void ScoringPoint()
    {
        if (isCarrying == true)
        {
            foreach (GameObject gameObject in collectedDivers)
            {
                dome.transform.Find("ScubaDiver(Clone)").transform.rotation = upRight;
                dome.transform.Find("ScubaDiver(Clone)").transform.gameObject.tag = "DiverSaved";
                dome.transform.Find("ScubaDiver(Clone)").transform.parent = null;
                GameManager.instance.score = GameManager.instance.score + (GameManager.instance.divervalue * cargoCount);
                GameManager.instance.currentvalueforpopup = GameManager.instance.divervalue;
                isCarrying = false;
                GameManager.instance.subCarryingCapacity += cargoCount;
                cargoCount = 0;
                timer.timeLeft = timer.timeLeft + 30f;
                scoreboard.makePopUpOnScore();
                collectedDivers = new List<GameObject>();
            }
            if (GameManager.instance.currentDivers.Count < 1)
            {
                GameManager.instance.BeatingLevel();
            }
        }
    }
    public void ClearCollectedDivers()
    {
        collectedDivers = new List<GameObject>();
    }

    private void OnTriggerExit(Collider backinwater)
    {
        if (backinwater.gameObject.tag == "Surface")
        {
            mufflesound.enabled = false;
            rigidBody.useGravity = false;
            rigidBody.mass = 1;
            rigidBody.drag = 2.61f;
            engineOff = false;
            rigidBody.freezeRotation = true;
        }
    }

    private void DeathSequence()
    {
        state = State.Dying;
        audioSource1.Stop();
        audioSource1.PlayOneShot(deathSound);
        dome.transform.position = dome.transform.position;
        popo.transform.position = popo.transform.position;
        Invoke("LoadCurrentLevel", levelLoadDelay);
    }

    private void SuccessSequence()
    {
        audioSource1.Stop();
        audioSource1.PlayOneShot(winSound);
        state = State.Transcending;
        Invoke("LoadNextLevel", 2.5f); // parameterise time
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
    private void LoadCurrentLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        GameManager.instance.CurrentLevel();
    }
}
