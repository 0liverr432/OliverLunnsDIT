using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathparameters : MonoBehaviour
{
    public float health = 100f;
    public Vector3 Spawn;
    public Transform Player;
    public HealthBar healthBar;

    private float currentHealth;
    private float maxHealth = 100f;

    void Start()
    {
        health = 100f;
        Spawn = new Vector3(0f, 0f, 0f);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth((int)maxHealth); // Cast to int
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Assuming the object has an "Enemy" tag
        {
            health = -100f; 
            Death();
        }
    }

    void Death()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth((int)currentHealth); // Cast to int

        if (currentHealth <= 0)
        {
            Death();
        }
    }
}
