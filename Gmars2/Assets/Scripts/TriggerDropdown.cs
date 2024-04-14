using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDropdown : MonoBehaviour
{
    public Animator animator;
    [SerializeField] GameObject gpt;

    public void PlayDropdownAnimation()
    {
        animator.Play("Dropdown");
        print("Dropping down");
        gpt.SetActive(false);
    }

    public void PlayPullupAnimation()
    {
        animator.Play("Pullup");
        print("Pulling up");
        gpt.SetActive(true);
    }

}
