using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathparameters : MonoBehaviour
{
    public float health = 100f;    //health of player 
    public Vector3 Spawn;    //spawn point
    public Transform Player;    //so the game knows what the player object is 
    public HealthBar healthBar;    //health bar UI 

    private float currentHealth;    //current health of the player 
    private float maxHealth = 100f;    //maximum health the player can have

    void Start()
    {
        health = 100f;    //sets players health at the start of the game
        Spawn = new Vector3(0f, 0f, 0f);    //sets the spawn point
        currentHealth = maxHealth;
        healthBar.SetMaxHealth((int)maxHealth); //sets the healthbar to current health
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) //detects enemy through their tag 
        {
            health = -100f;   //kills the player 
            Death(); //function for death
        }
    }

    void Death()
    {
        SceneManager.LoadScene(2);    //loads the death menu
        Cursor.lockState = CursorLockMode.None;    //shows cursor and makes it visible
        Cursor.visible = true;
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;    //damage taken by player from object 

        healthBar.SetHealth((int)currentHealth); //sets healthbar

        if (currentHealth <= 0) //if health is 0 or negative then player dies
        {
            Death();
        }
    }
}
