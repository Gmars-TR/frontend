using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRover : MonoBehaviour
{
    [SerializeField] Transform planet;
    public float strength = 3.71f;
    public float movementMulti = 2f;
    Camera cam;
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
            rb.velocity += transform.right * movementMulti * Time.deltaTime;
            print(transform.forward);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        Attract();
        Move();
    }

}
