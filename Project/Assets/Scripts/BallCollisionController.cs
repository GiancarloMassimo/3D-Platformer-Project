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
        Physics.IgnoreLayerCollision(6, 6);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.KnockBack();
            print(playerMovement.knockedBack);
            player.constraints = RigidbodyConstraints.None;
            player.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
            player.AddForce(transform.right * knockbackMagnitude, ForceMode.Impulse);
        }

    }
}
