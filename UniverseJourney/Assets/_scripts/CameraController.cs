using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraHolder;
    public Transform playerTransform;
    public float mouseSensivity = 2f;
    public float upLimit = -50f;
    public float bottomLimit = 50f;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {

        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        playerTransform.Rotate(0, horizontalRotation * mouseSensivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 188) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, bottomLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);

    }
}
