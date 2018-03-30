using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Submarine : MonoBehaviour {

    //public count how many scuba people you have
    

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip winSound;

    [SerializeField] float rcsThrust = 150f;
    [SerializeField] float mainThrust = 1f;
    [SerializeField] float levelLoadDelay = 2f;

    enum State {  Alive, Dying, Transcending }
    State state = State.Alive;



    //PIECES THAT FALL OFF WHEN DEAD
    public GameObject dome;
    public GameObject popo;

    //CARRYING LOGIC
    public bool isCarrying = false;
    public int carryingCapacity = 1;
    public static int score = 0;
    public TimerScript timer;
    public static int cargoCount = 0;

    //LIGHT CONTROLS
    public bool lightControl;
    public GameObject topLight;
    public GameObject leftLight;
    public GameObject rightLight;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

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
        if (Input.GetKey(KeyCode.W))
            ApplyThrust();
        else
        {
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddRelativeForce(Vector3.down * mainThrust);
        }
    }
    // THRUST STRENGTH
    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust);
        // So audio doesn't layer
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    private void RespondToRotateInput()
    {
        // Freezing rotation as soon as we rotate
        rigidBody.freezeRotation = true;
        // Turning Power
        float rotationThisFrame = rcsThrust * Time.deltaTime;

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
        rigidBody.freezeRotation = false;
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
                ScoringPoint();
                break;
            case "Grippable":
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                DeathSequence();
                break;
        }
    }
    // SCORING A POINT WITH A SCUBA GUY
    private void ScoringPoint()
    {
        if (isCarrying == true)
        {
            dome.transform.Find("ScubaDiver").transform.gameObject.tag = "Friendly";
            dome.transform.Find("ScubaDiver").transform.parent = null;
            
            score = score + cargoCount;
            isCarrying = false;
            carryingCapacity = carryingCapacity + 1;
            TimerScript.timeLeft = TimerScript.timeLeft + 30f;
        }
    }
    // COLLIDING WITH SCUBA DIVER
    private void OnTriggerEnter(Collider scuba)
    {
        if (scuba.gameObject.tag == "Diver" && carryingCapacity >= 1f)
        {
            scuba.transform.parent = dome.transform;
            scuba.gameObject.transform.position = dome.transform.position + dome.transform.right * .3f;
            scuba.transform.rotation = Quaternion.identity;
            isCarrying = true;
            carryingCapacity = carryingCapacity - 1;
            cargoCount = cargoCount + 1;
        }
    }
    private void DeathSequence()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound);
        dome.transform.parent = null;
        popo.transform.parent = null;
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void SuccessSequence()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
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
