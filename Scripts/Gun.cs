using UnityEngine;
using System.Collections;
using System;
public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float firerate = 15f; 
    public float range = 100f;
    public float impactforce = 30f; 

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/firerate;
            Shoot();
            muzzleFlash.Play();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            muzzleFlash.Play();
        }
    
    }
    
    void Shoot ()
    {
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
                hit.rigidbody.AddForce(-hit.normal * impactforce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}