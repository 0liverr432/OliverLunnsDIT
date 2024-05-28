using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 0.5f; // Adjust the fire rate as needed

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private bool canShoot = true;

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        canShoot = false;
        Shoot();
        yield return new WaitForSeconds(1f / fireRate);
        canShoot = true;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
