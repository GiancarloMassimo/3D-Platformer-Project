using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
    [SerializeField]
    Transform firstPersonCameraPosition;

    [SerializeField]
    Transform thirdPersonCameraPosition;

    bool firstPerson = false;
    Transform cameraPosition;

    private void Start()
    {
        cameraPosition = thirdPersonCameraPosition;        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCamera();
        }
        transform.position = cameraPosition.position;
    }

    void ToggleCamera()
    {
        firstPerson = !firstPerson;
        if (firstPerson)
        {
            cameraPosition = firstPersonCameraPosition;
        }
        else
        {
            cameraPosition = thirdPersonCameraPosition;
        }
    }
}
