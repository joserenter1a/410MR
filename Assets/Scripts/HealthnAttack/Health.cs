using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int StartingHealth = 100;
    public int health;


    void Start()
    {
        health = StartingHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {

            Destroy(gameObject);
        }
    }
    
}
