using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpinController : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.angularVelocity = transform.forward * speed;
    }
}
