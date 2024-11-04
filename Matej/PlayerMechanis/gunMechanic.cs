using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMechanic : MonoBehaviour
{
   
    public float dmg = 10f;
    public float range = 50f;

    public Camera fpsCam;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
