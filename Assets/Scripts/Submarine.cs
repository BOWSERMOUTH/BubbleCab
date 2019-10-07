using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Submarine : MonoBehaviour {

    //public count how many scuba people you have

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

    public float rotationThrust = 150f;
    [SerializeField] float mainThrust = 1f;
    [SerializeField] float levelLoadDelay = 2f;

    enum State {  Alive, Dying, Transcending }
    State state = State.Alive;

    public TimerScript timer;

    //PIECES THAT FALL OFF WHEN DEAD
    public GameObject dome;
    public GameObject popo;
    //DAMAGE LOGIC
    public static bool invincibility;
    public bool bubbleBoost;
    public static int hull = 3;
    //CARRYING LOGIC
    public bool isCarrying = false;
    public int carryingCapacity = 1;
    public static int score = 0;
    public static int cargoCount = 0;

    //LIGHT CONTROLS
    public bool lightControl;
    public GameObject topLight;
    public GameObject leftLight;
    public GameObject rightLight;

    public bool engineOffOutside;

    //SCUBA MAN UPRIGHT
    private Quaternion upRight = Quaternion.Euler(-50, -90, 0);

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        hull = 3;

    }
    private void ApplyThrust()
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
            //add pickup scubadiver method
        }
	}

    // CONTROLS LIGHTS WITH F
    private void lightsOnOff()
    {
        if (Input.GetKeyDown(KeyCode.F))
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
        if (engineOffOutside == true)
        {
            mainThrust = 0f;
        }
        if (Input.GetKey(KeyCode.LeftShift) && engineOffOutside == false)
        {
            mainThrust = 20f;
            audioSource1.pitch = 1.6f;
        }

        else if (engineOffOutside == false)
        {
            mainThrust = 10f;
            audioSource1.pitch = .6f;
        }
        if (Input.GetKey(KeyCode.W))
            ApplyThrust();

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
            case "Surface":
                break;
            case "Grippable":
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                hull = hull - 1;
                audioSource2.PlayOneShot(hurt);
                if (hull < 1)
                    {
                    DeathSequence();
                    }
                break;
        }
    }
    // SCORING A POINT WITH A SCUBA GUY
    private void ScoringPoint()
    {
        if (isCarrying == true)
        {
            dome.transform.Find("ScubaDiver(Clone)").transform.rotation = upRight;
            dome.transform.Find("ScubaDiver(Clone)").transform.gameObject.tag = "Friendly";
            dome.transform.Find("ScubaDiver(Clone)").transform.parent = null;
            score = score + cargoCount;
            cargoCount = 0;
            isCarrying = false;
            carryingCapacity = carryingCapacity + 1;
            timer.timeLeft = timer.timeLeft + 30f;
            // MAKE MONEY
            scoreboard.makePopUpOnScore();
        }
    }

    // COLLIDING WITH SCUBA DIVER
    private void OnTriggerEnter(Collider collidedwith)
    {
        if (collidedwith.gameObject.tag == "Diver" && carryingCapacity >= 1f)
        {
            collidedwith.transform.parent = dome.transform;
            collidedwith.gameObject.transform.position = dome.transform.position + dome.transform.right * .3f;
            collidedwith.transform.rotation = Quaternion.identity;
            isCarrying = true;
            carryingCapacity = carryingCapacity - 1;
            cargoCount = cargoCount + 1;
            audioSource1.PlayOneShot(grabbedScuba, 1);

        }
    }
    private void OnTriggerStay(Collider outofwater)
    {
        if (outofwater.gameObject.tag == "Surface")
        {
            rigidBody.useGravity = true;
            rigidBody.mass = 3;
            rigidBody.drag = 1;
            engineOffOutside = true;
            rigidBody.freezeRotation = false;
            print("i've touched the surface");
            ScoringPoint();
        }
    }
    private void OnTriggerExit(Collider backinwater)
    {
        if (backinwater.gameObject.tag == "Surface")
        {
            rigidBody.useGravity = false;
            rigidBody.mass = 1;
            rigidBody.drag = 2.61f;
            engineOffOutside = false;
            rigidBody.freezeRotation = true;
        }
    }
    private void DeathSequence()
    {
        state = State.Dying;
        audioSource1.Stop();
        audioSource1.PlayOneShot(deathSound);
        dome.transform.parent = null;
        popo.transform.parent = null;
        Invoke("LoadFirstLevel", levelLoadDelay);
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
}
