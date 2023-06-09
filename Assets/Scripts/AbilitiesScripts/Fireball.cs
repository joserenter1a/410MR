using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 50;
    public float maxDistance = 100f;

    private Rigidbody rb;
    private Vector3 startingPosition;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Set the initial velocity of the fireball
        rb.velocity = transform.forward * speed;
        //startingPosition = transform.position; // Record the starting position

        Destroy(gameObject, 2f);

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Human"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the fireball object
            //Destroy(gameObject);
        }
}   }
