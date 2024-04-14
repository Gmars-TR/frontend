using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] Transform planet;
    [SerializeField] Transform rover;
    [SerializeField] float offset = 10f;
    void Update()
    {
        Vector3 position = rover.position - planet.position;
        transform.position = planet.position + position + position.normalized * offset;
        transform.LookAt(planet.position);
    }
}
