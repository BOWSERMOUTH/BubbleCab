using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSparkle : MonoBehaviour
{
    private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = gameObject.GetComponent<ParticleSystem>();
        particles.Play(true);
        Invoke("destroySelf", 2f);
    }
    void destroySelf()
    {
        Destroy(gameObject);
    }
}
