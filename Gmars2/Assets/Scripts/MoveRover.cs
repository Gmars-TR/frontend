using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRover : MonoBehaviour
{
    [SerializeField] Transform planet;
    [SerializeField] ParticleSystem dirt;
    public float strength = 3.71f;
    public float movementMulti = 2.5f;
    public float turnStrength = 0.2f;
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
        if (Input.GetKey("w"))
        {
            var emission = dirt.emission;
            emission.rateOverTime = 10f;
            rb.velocity += transform.forward * movementMulti * Time.deltaTime;
        }
        else
        {
            var emission = dirt.emission;
            emission.rateOverTime = 0f;
        }
        if (Input.GetKey("s"))
        {
            rb.velocity -= transform.forward * movementMulti * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            rb.AddTorque(-transform.up * turnStrength);
        }
        if (Input.GetKey("d"))
        {
            rb.AddTorque(transform.up * turnStrength);
        }
        if (!Input.anyKey)
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        Attract();
    }

    void FixedUpdate()
    {
        Move();
    }

}
