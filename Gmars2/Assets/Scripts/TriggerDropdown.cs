using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDropdown : MonoBehaviour
{
    public Animator animator;

    public void PlayDropdownAnimation()
    {
        animator.Play("Dropdown");
        print("Dropping down");
    }

    public void PlayPullupAnimation()
    {
        animator.Play("Pullup");
        print("Pulling up");
    }

}
