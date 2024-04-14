using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.01f;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        // Calculate the desired position and rotation of the camera
        Vector3 desiredPosition = target.position;
        Quaternion desiredRotation = target.rotation;

        // Smoothly interpolate between the current position/rotation and the desired position/rotation
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);

        // Apply the interpolated position and rotation to the camera
        transform.position = smoothedPosition;
        transform.rotation = smoothedRotation;
    }
}
