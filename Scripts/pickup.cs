using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlight : MonoBehavior
{
    public GameObject PickUpText;
    public GameObject FlashlightOnPlayer;
    
    void Start()
    {
        FlashlightOnPlayer.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            PickUpText.SetActive(true);
            
            
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                
                FlashlightOnPlayer.SetActive(true);
                
                PickUpText.SetActive(false);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
       PickUpText.SetActive(false); 
    }
    
}  
    