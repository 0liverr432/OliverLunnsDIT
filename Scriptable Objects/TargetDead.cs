using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDead : MonoBehaviour, IDamageable {

    public float health;
    public GameObject shootText;
    public GameObject winblock;

    void Start()
    {
        shootText.SetActive(false);
        winblock.SetActive(false);
        health = 100f;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            Destroy(gameObject);
            ChangeStuff();
        }
    }

    public void ChangeStuff()
    {
        shootText.SetActive(true);
        winblock.SetActive(true);
    }






}