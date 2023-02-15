using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("stuck");
            other.GetComponent<PlayerMovementController>().Stick();
        }
    }
}
