using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    [SerializeField]
    float knockbackMagnitude;

    [SerializeField]
    float liftForce;

    Rigidbody player;
    PlayerMovementController playerMovement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerMovement = player.GetComponent<PlayerMovementController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
            player.AddForce(transform.right * knockbackMagnitude, ForceMode.Impulse);
            playerMovement.KnockBack();
        }
    }
}