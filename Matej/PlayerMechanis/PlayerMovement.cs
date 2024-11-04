using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float gravity = -10f;
    public float jump = 3f;

    public Transform gCheck;
    public float gDistance = 0.4f;
    public LayerMask gMask; 

    Vector3 velocity;

    bool isG;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isG = Physics.CheckSphere(gCheck.position, gDistance, gMask);

        if(isG && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float wX = Input.GetAxis("Horizontal");
        float wZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * wX + transform.forward * wZ;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isG) 
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
