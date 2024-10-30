using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
   
   public int Playerhealth;
   public int Currentplayerhealth;
   
   public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        Playerhealth = 100;
        Currentplayerhealth = 100;
        healthBar.SetMaxHealth(Playerhealth);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TakeDamage(20);
        }

        if (Currentplayerhealth <= 0)
        {
            Die();
        }
    }

    void TakeDamage(int damage)
    {
        Currentplayerhealth -= damage;
        healthBar.SetHealth(Currentplayerhealth);
    }

    void Die()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }
}
