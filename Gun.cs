using System.Collections;
using UnityEngine

public class Gun : MonoBehaviour
{
    public float damage = 10f;    //the amount of damage the gun will do
    public float range = 100f;    //the range the raycast will go to until 
    public float fireRate = 0.5f; //how often the gun will fire

    public Camera fpsCam;    //the main camera for the player
    public ParticleSystem muzzleFlash;    //the particle effect for when the gun fires 

    private bool canShoot = true;    //used in order to set firerate

    void Update()    //this function is called every frame
    {
        if (Input.GetButton("Fire1") && canShoot)    //finds when the left mouse button has been clicked 
        {
            StartCoroutine(ShootWithDelay());    //calls the shoot function
        }
    }
    
    IEnumerator ShootWithDelay()    //sets the function and makes it so that firerate can be used 
    {
        canShoot = false;    //so that gun firerate isnt infinite
        Shoot(); // function fires a raycast to the middle of screen from gun barrel
        yield return new WaitForSeconds(1f / fireRate);    //firerate
        canShoot = true;    //now can be shot again
    }

    void Shoot()    //function to shoot
    {
        muzzleFlash.Play();    //muzzle flash so you know when ou have fired 

        RaycastHit hit;    //shoots a ray in the direction of the player
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))    //finds where to shoot and if target is in range
        {
            Debug.Log(hit.transform.name);    //displays the name in the console; used for testing and debugging mostly

            Target target = hit.transform.GetComponent<Target>();    //takes health away from target
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
