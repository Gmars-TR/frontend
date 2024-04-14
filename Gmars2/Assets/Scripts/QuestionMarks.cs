using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarks : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] GameObject rover;

    // Update is called once per frame
    void Update()
    {
        foreach (Transform questionMark in transform)
        {
            // Calculate the direction from this object to the camera
            Vector3 directionToCamera = cam.position - questionMark.position;

            // Create a rotation based on the calculated direction
            Quaternion rotationToCamera = Quaternion.LookRotation(directionToCamera, Vector3.up);

            // Rotate the rotation to align the specified side with the camera
            Quaternion sideRotation = Quaternion.FromToRotation(transform.forward, -Vector3.up) * rotationToCamera;

            // Apply the rotation to this object
            questionMark.rotation = sideRotation;
        }
    }
}
