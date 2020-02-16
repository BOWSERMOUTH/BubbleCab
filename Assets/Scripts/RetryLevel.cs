using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
