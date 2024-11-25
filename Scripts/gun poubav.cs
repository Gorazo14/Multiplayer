using UnityEngine;


public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public GameObject impactEffect;

    public int ammoCounter = 30;
    public int ammoCount = 0;

    private float nextTimeToFire = 0f;


    // Update is called once per frame
    void Update() {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            ammoCounter--;
            Shoot();
        }
        Debug.Log(ammoCounter);
        {  // Handle shooting if not reloading
            if (!isReloading)
            {
                if (Input.GetButtonDown("Fire1") && currentAmmo > 0)  // Fire button (usually mouse button 0)
                {
                    ShootRaycast();
                }

                // Reload if ammo is out
                if (currentAmmo <= 0)
                {
                    StartCoroutine(Reload());
                }
            }
        }

        public void ShootRaycast()
        {
            // Raycast from the camera's center to detect objects
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, raycastRange, shootableLayer))
            {
                Debug.Log("Hit " + hit.collider.name);  // Just an example to log the hit object
                                                        // Here you would handle applying damage or effects to the hit object
            }

            // Decrease ammo count after firing
            currentAmmo--;
            Debug.Log("Ammo: " + currentAmmo);
        }

        private System.Collections.IEnumerator Reload()
        {
            if (isReloading)
                yield break;  // Prevent starting reload if already reloading

            isReloading = true;
            Debug.Log("Reloading...");

            // Wait for reloadTime (e.g., 2 seconds)
            yield return new WaitForSeconds(reloadTime);

            // After reloading, reset ammo to maxAmmo
            currentAmmo = maxAmmo;
            Debug.Log("Reloaded! Ammo: " + currentAmmo);

            isReloading = false;
        }

    } }

void Shoot()
{  {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);            
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);   
            }

           GameObject impactGo = Instantiate (impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }
    }
}
 
    public int maxAmmo = 30;             // Maximum number of bullets in the gun
private int currentAmmo;             // Current ammo count
public float reloadTime = 2f;        // Time it takes to reload (in seconds)
private bool isReloading = false;    // Is the gun currently reloading?

public Camera playerCamera;          // Reference to the player's camera for Raycasting
public float raycastRange = 100f;    // Range of the Raycast for shooting
public LayerMask shootableLayer;     // The layer(s) that can be shot

private void Start()
{
    // Initialize the ammo count to maxAmmo
    currentAmmo = maxAmmo;
}



