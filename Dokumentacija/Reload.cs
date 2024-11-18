using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField] private int reloadCounter = 10;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private Gun gun;
    private void Start()
    {
        gun.enabled = true;
    }
    private void Update()
    {
        if (reloadCounter >= 10)
        {
            gun.enabled = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            reloadCounter--;
        }
        if (reloadCounter <= 0)
        {
            Invoke("ReloadGun", cooldown);
            gun.enabled = false;
        }
    }
    private void ReloadGun ()
    {
        reloadCounter = 10;
    }
}
