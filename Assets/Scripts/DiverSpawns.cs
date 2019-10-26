using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverSpawns : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public int maxDivers = 3;
    public GameObject diver;
    public List<int> usedIds;
    int random;

    void Start ()
    {
    }
    private void spawnDiverIntro()
    {
        do
        {
            random = Random.Range(0, spawnPoints.Length);
        }
        while (usedIds.IndexOf(random) != -1);

        usedIds.Add(random);
        Instantiate(diver, spawnPoints[random], Quaternion.Euler(0,-90,0));
        maxDivers = maxDivers -1;
    }
    private void preventSameSpawn()
    {
    }
    public void diverspawnonupdate()
    {
        if (maxDivers < 1)
        {
            return;
        }
        else
            spawnDiverIntro();
    }
	void Update ()
    {
        diverspawnonupdate();
    }
    
}
