using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverSpawns : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public int maxDivers = 3;
    public GameObject diver;
    public List<int> usedIds;
    int r;

    void Start ()
    {
    }
    private void spawnDiverIntro()
    {
        do
        {
            r = Random.Range(0, spawnPoints.Length);
        }
        while (usedIds.IndexOf(r) != -1);

        usedIds.Add(r);
        Instantiate(diver, spawnPoints[r], Quaternion.Euler(0,-90,0));
        maxDivers = maxDivers -1;
    }
    private void preventSameSpawn()
    {
    }

	void Update ()
    {
        if (maxDivers < 1)
        {
            return;
        }
        else
        spawnDiverIntro();
	}
}
