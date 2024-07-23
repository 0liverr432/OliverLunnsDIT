using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f; //variable for health of the target
    
    public void TakeDamage (float amount)
    {
        health -= amount; //takes of health
        if (health <= 0f)
        {
            Die();    //kills the target
        }
    }
    void Die ()
    {
        Destroy(gameObject); //makes the object dissapear
    }
}


