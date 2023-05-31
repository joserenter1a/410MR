using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Set the initial velocity of the fireball
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Human"))
        {
            // Apply damage to the enemy
            //Enemy enemy = other.GetComponent<Enemy>();
            //if (enemy != null)
           // {
          //      enemy.TakeDamage(damage);
          //  }

            // Destroy the fireball
         //   Destroy(gameObject);
        }
}   }
