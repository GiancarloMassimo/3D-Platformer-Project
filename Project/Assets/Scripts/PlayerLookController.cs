using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    [SerializeField]
    float sensitivity;

    [SerializeField]
    Transform playerCam;

    float xRotation;

    void Start()
    {
        DisableCursor();
    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        Vector2 input = GetInput();

        Vector3 rotation = playerCam.localRotation.eulerAngles;
        float yRotation = rotation.y + input.x;

        xRotation -= input.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCam.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

    Vector2 GetInput()
    {
        return new Vector2(
            Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime,
            Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime
        );
    }

    void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
