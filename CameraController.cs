using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Camera;
    public float Sensitivity;

    float xRotation;
    float MouseX;
    float MouseY;

    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * MouseX);

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        Camera.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
