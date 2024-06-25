using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private int health;  // Define the health variable at the class level

    // Set the maximum health value on the slider
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        this.health = health;  // Initialize the health variable
    }

    // Set the current health value on the slider
    public void SetHealth(int health)
    {
        slider.value = health;
        this.health = health;  // Update the health variable
    }

    void Start()
    {
        // Initialize health if necessary
        SetMaxHealth(100); // Example initial health value
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Damage");
            health -= 10;  // Decrease health by 10 (or any other value)
            SetHealth(health);  // Update the slider with the new health value
        }
    }
}
