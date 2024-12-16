using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendTree_2D : MonoBehaviour
{
    private Animator animator;
    private float velocityX = 0.0f;
    private float velocityZ = 0.0f;

    [SerializeField] private float forwardAcceleration = 0.1f;
    [SerializeField] private float forwardDeceleration = 0.5f;
    [SerializeField] private float sideAcceleration = 0.1f;
    [SerializeField] private float sideDeceleration = 0.5f;

    [SerializeField] private float maxRunSpeed = 2f;
    [SerializeField] private float maxWalkSpeed = 0.5f;

    private float currentMaxSpeed = 0.0f;
     
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.W);
        bool isBackwardsWalking = Input.GetKey(KeyCode.S);
        bool isLeftWalking = Input.GetKey(KeyCode.A);
        bool isRightWalking = Input.GetKey(KeyCode.D);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("IsAiming", true);
        }
        if (!Input.GetMouseButton(1))
        {
            animator.SetBool("IsAiming", false);
        }

        if (isJumping)
        {
            animator.SetTrigger("IsJumping");
        }
        if (isRunning)
        {
            currentMaxSpeed = maxRunSpeed;
        }
        if (!isRunning)
        {
            currentMaxSpeed = maxWalkSpeed;
            if (velocityZ > maxWalkSpeed)
            {
                velocityZ -= forwardDeceleration * Time.deltaTime;
            }
            if (velocityX > maxWalkSpeed)
            {
                velocityX -= sideDeceleration * Time.deltaTime;
            }
        }

        if (isWalking && velocityZ < currentMaxSpeed)
        {
            velocityZ += forwardAcceleration * Time.deltaTime;
        }
        if (!isWalking && velocityZ > 0f)
        {
            velocityZ -= forwardDeceleration * Time.deltaTime;
        }
        if (isBackwardsWalking && velocityZ > -currentMaxSpeed)
        {
            velocityZ -= forwardAcceleration * Time.deltaTime;
        }
        if (!isBackwardsWalking && velocityZ < 0f)
        {
            velocityZ += forwardDeceleration * Time.deltaTime;
        }
        if (isRightWalking && velocityX < currentMaxSpeed)
        {
            velocityX += sideAcceleration * Time.deltaTime;
        }
        if (!isRightWalking && velocityX > 0f)
        {
            velocityX -= sideDeceleration * Time.deltaTime;
        }
        if (isLeftWalking && velocityX > -currentMaxSpeed)
        {
            velocityX -= sideAcceleration * Time.deltaTime;
        }
        if (!isLeftWalking && velocityX < 0f)
        {
            velocityX += sideDeceleration * Time.deltaTime;
        }

    

        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }

}
