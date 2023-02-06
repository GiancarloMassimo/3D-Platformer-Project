using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedLineController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem speedLines;

    [SerializeField]
    float minSpeed;

    [SerializeField]
    float particleRate;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;
        if (speed > minSpeed)
        {
            var emission = speedLines.emission;
            emission.rateOverTime = (speed - minSpeed) * particleRate;
        }
        else
        {
            var emission = speedLines.emission;
            emission.rateOverTime = 0;
        }
    }
}
