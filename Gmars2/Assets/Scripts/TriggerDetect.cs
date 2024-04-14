using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        animator.Play("Exit");
    }

    void OnTriggerExit(Collider other)
    {
        animator.Play("Enter");
    }

}
