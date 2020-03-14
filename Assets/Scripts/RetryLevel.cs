using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RetryLevel : MonoBehaviour
{
    EventSystem eventSystem;
    private void OnEnable()
    {
        eventSystem = UnityEngine.EventSystems.EventSystem.current;
        eventSystem.SetSelectedGameObject(gameObject);
    }
    public void retryLevel()
    {
        GameManager.instance.CurrentLevel();
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
