using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mX = Input.GetAxis("Mouse X") * mSensitivity * Time.deltaTime;
        float mY = Input.GetAxis("Mouse Y") *mSensitivity * Time.deltaTime;

        xRotation -= mY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mX);
    }
}
