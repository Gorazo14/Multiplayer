using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.W);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isWalking)
        {
            animator.SetBool("IsWalking", true);
        }
        if (!isWalking)
        {
            animator.SetBool("IsWalking", false);
        }
        if (isWalking && isRunning)
        {
            animator.SetBool("IsRunning", true);
        }
        if (!isRunning)
        {
            animator.SetBool("IsRunning", false);
        }
    }
}
