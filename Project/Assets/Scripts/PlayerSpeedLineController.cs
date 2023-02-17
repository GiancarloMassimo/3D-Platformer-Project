using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerSpeedLineController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem speedLines;

    [SerializeField]
    float minSpeed;

    [SerializeField]
    float particleRate;

    [SerializeField]
    Volume volume;

    LensDistortion lensDistortion;
    float distortionTarget = 0;

    [SerializeField]
    float lensAcceleration = 1;

    [SerializeField]
    float lensDeceleration = 1;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        volume.profile.TryGet(out lensDistortion);
        lensDistortion.intensity.value = 0;
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;
        if (speed > minSpeed)
        {
            var emission = speedLines.emission;
            emission.rateOverTime = (speed - minSpeed) * particleRate;
            lensDistortion.intensity.value = 0.35f + Mathf.Max(-0.6f, (speed - minSpeed) * -0.1f);
        }
        else if (!GetComponent<PlayerMovementController>().isControlEnabled)
        {
            lensDistortion.intensity.value = Mathf.MoveTowards(lensDistortion.intensity.value, 0.35f, 1.5f * Time.deltaTime);
        }
        else
        {
            var emission = speedLines.emission;
            emission.rateOverTime = 0;
            lensDistortion.intensity.value = Mathf.MoveTowards(lensDistortion.intensity.value, 0, 2 * Time.deltaTime);
        }
    }
}
