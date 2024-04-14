using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolarSystem : MonoBehaviour
{

    //real value of gravitational constant is 6.67408 × 10-11
    //can increase to make thing go faster instead of increase timestep of Unity
    readonly float G = 1000f;
    GameObject[] celestials;

    [SerializeField]
    bool IsElipticalOrbit = false;

    // Start is called before the first frame update
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestials");

        SetInitialVelocity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Gravity();
    }

    void SetInitialVelocity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.transform.LookAt(b.transform);

                    if (IsElipticalOrbit)
                    {
                        // Eliptic orbit = G * M  ( 2 / r + 1 / a) where G is the gravitational constant, M is the mass of the central object, r is the distance between the two bodies
                        // and a is the length of the semi major axis (!!! NOT GAMEOBJECT a !!!)
                        a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) * ((2 / r) - (1 / (r * 1.5f))));
                    }
                    else
                    {
                        //Circular Orbit = ((G * M) / r)^0.5, where G = gravitational constant, M is the mass of the central object and r is the distance between the two objects
                        //We ignore the mass of the orbiting object when the orbiting object's mass is negligible, like the mass of the earth vs. mass of the sun
                        a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
                    }
                }
            }
        }
        // Draw orbits
        foreach (GameObject celestial in celestials)
        {
            DrawOrbit(celestial);
        }
    }

    void Gravity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }

    void DrawOrbit(GameObject celestial)
    {
        LineRenderer lineRenderer = celestial.GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = celestial.AddComponent<LineRenderer>();
        }

        lineRenderer.positionCount = 360; // Number of points to draw the orbit
        lineRenderer.useWorldSpace = false; // Use local space of the celestial object
        lineRenderer.startWidth = 0.05f; // Adjust the width of the orbit
        lineRenderer.endWidth = 0.05f;

        Vector3[] positions = new Vector3[360];
        for (int i = 0; i < 360; i++)
        {
            float angle = Mathf.Deg2Rad * i;
            float x = Mathf.Cos(angle) * celestial.transform.localScale.x;
            float z = Mathf.Sin(angle) * celestial.transform.localScale.z;
            positions[i] = new Vector3(x, 0, z);
        }

        lineRenderer.SetPositions(positions);
    }

    // Function to load a new scene
    public void LoadNewScene()
    {
        SceneManager.LoadScene("Assets/Scenes/Earth.unity");
    }
}
