using UnityEngine;
using UnityEngine.SceneManagement;

public class Submarine : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float rcsThrust = 150f;
    [SerializeField] float mainThrust = 1f;

    enum State {  Alive, Dying, Transcending }
    State state = State.Alive;

    public GameObject submarine; //FOOLING AROUND
    public GameObject popo;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }
	}

    // Controls
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            // So audio doesn't layer
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddRelativeForce(Vector3.down * mainThrust);
        }
    }
    private void Rotate()
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
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // Do Nothing
                break;
            case "Grippable":
                break;
            case "Finish":
                state = State.Transcending;
                Invoke("LoadNextLevel", 1f); // parameterise time
                break;
            default:
                state = State.Dying;
                submarine.transform.parent = null;
                popo.transform.parent = null;
                Invoke("LoadFirstLevel", 1f);
                break;
        }
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
