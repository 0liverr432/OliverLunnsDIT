using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [Header("References")]
    [SerializeField] private GunData gunData;           //variable used when creating new weapons
    [SerializeField] private Transform cam;             //player camera that raycasts are shot from
    [SerializeField] public ParticleSystem muzzleFlash; //the muzzleflash when shooting
    
    float timeSinceLastShot;                            //variable of time since the last ray was cast

    private void Start() {                              //function that is run once at the start of the game
        PlayerShoot.shootInput += Shoot;                //when player clicks mousebutton then Shoot() funciton is run
        PlayerShoot.reloadInput += StartReload;         //when player clicks R key the StartReload() function is run
    }

    private void OnDisable() => gunData.reloading = false;  //disables reloading once finished

    public void StartReload() {                         //the start of the reload function
        if (!gunData.reloading && this.gameObject.activeSelf)//seeing if the player is able to reload by checking whether they are already and if the gun is in use or not 
            StartCoroutine(Reload());                   //calling the actual reload function 
    }

    private IEnumerator Reload() {                      //the actuall reload
        gunData.reloading = true;                       //making sure that the script knows they are reloading

        yield return new WaitForSeconds(gunData.reloadTime);      //a wait function to balance reload time 

        gunData.currentAmmo = gunData.magSize;          //reloads the current ammo in weapon to maximum

        gunData.reloading = false;                      //tells script thta reloading is finished 
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f); //giving the weapon a firerate so that its not a laserbeam

    private void Shoot() {                              //Shooting function
        if (gunData.currentAmmo > 0) {                  //Checking if weapon has enough ammo to shoot
            if (CanShoot()) {   
                if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance)){
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.damage);
                    muzzleFlash.Play();
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
    }

    private void Update() {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);
    }

    private void OnGunShot() {  }
}