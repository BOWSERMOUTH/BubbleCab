using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool startgamebool = false;

    private void Start()
    {
        //StartCoroutine(LoadTheLevel());
    }
    public void PlayGame()
    {
        //startgamebool = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReturnToMenu()
    {
        GameManager.instance.ResetGameManager();
        SceneManager.LoadScene(0);
    }
    //IEnumerator LoadTheLevel()
    //{
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        //asyncLoad.allowSceneActivation = false;
        //while (!asyncLoad.isDone)
       // {
            //if (asyncLoad.progress >= .9f && startgamebool == true)
           // {
          //      asyncLoad.allowSceneActivation = true;
        //    }
      //      print(asyncLoad.progress * 10);
    //        yield return null;
        //}
    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
