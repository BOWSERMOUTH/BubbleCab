using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverSpawnPoints : MonoBehaviour
{
    public Vector3[] spawnPoints;
    private Quaternion upRight = Quaternion.Euler(-50,-90,0);

    private void OnCollisionEnter(Collision surface)
    {
        if (surface.gameObject.tag == "Surface")
        {
            transform.rotation = upRight;
            print("I'm trying to turn him upright");
        }
    }
}
