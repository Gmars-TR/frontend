using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRover : MonoBehaviour
{
    [SerializeField] Transform planet;
    public float strength = 3.71f;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Attract()
    {
        Vector3 dirOfGrav = transform.position - planet.position;
        rb.velocity -= dirOfGrav.normalized * strength * Time.deltaTime;
    }

    void Move()
    {

    }

    void Update()
    {
        Attract();
    }

}
