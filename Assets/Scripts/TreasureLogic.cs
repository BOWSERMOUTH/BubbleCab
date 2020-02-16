using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureLogic : MonoBehaviour
{
    public GameObject treasureSparkle;
    

    private void OnTriggerEnter(Collider collidedwith)
    {
        if (collidedwith.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Instantiate(treasureSparkle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
