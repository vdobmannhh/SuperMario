using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float startTime;
    private float animationDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        animationDuration = GetComponent<ParticleSystem>().main.duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= animationDuration)
        {
            gameObject.SetActive(false);
        }
    }
}
