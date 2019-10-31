using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip starthighlight;
    public AudioClip startclick;
    public Submarine submarine;
    void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        
        audio = gameObject.GetComponent<AudioSource>();
        Time.timeScale = 0;
        submarine.engineOff = true;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
        submarine.engineOff = false;
    }
    public void HoverSound()
    {
        audio.PlayOneShot(starthighlight);
    }
    public void ClickSound()
    {
        audio.PlayOneShot(startclick);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Destroy(GameManager.instance);
        SceneManager.LoadScene(0);
    }
    public void UnPause()
    {
        gameObject.SetActive(false);
        print("gamemanager is now set to unpaused");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
