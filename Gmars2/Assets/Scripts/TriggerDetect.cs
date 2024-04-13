using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        transform.Find("Info").gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        transform.Find("Info").gameObject.SetActive(false);
    }

}
