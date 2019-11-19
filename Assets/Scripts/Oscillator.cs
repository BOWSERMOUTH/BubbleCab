using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    public float oscSpeed = 2f;
    [Range(0,1)] [SerializeField] float movementFactor; // 0 for not moved, 1 for fully moved.

    Vector3 startingPos;

	void Start ()
    {
        startingPos = transform.position;
	}
	
	void Update ()
    {
        if (oscSpeed <= Mathf.Epsilon) { return; }
        float cycles = Time.time / oscSpeed; // grows continually from 0

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
