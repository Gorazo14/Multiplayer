using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendTree_1D : MonoBehaviour
{
    private Animator animator;
    private float velocity = 0.0f;

    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float deceleration = 0.5f;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.W);

        if (isWalking && velocity < 1f)
        {
            velocity += acceleration * Time.deltaTime;
        }
        if (!isWalking && velocity > 0f)
        {
            velocity -= deceleration * Time.deltaTime;
        }
        if (!isWalking && velocity < 0f)
        {
            velocity = 0f;
        }
        animator.SetFloat("Velocity", velocity);
    }
}
