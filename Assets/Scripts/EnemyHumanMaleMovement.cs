using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHumanMaleMovement : MonoBehaviour
{
    Animator m_Animator;
    public GameObject target; // reference to the target game object
    public float speed; // the speed at which the enemy should move
    public Transform lookTarget;
    private float originalSpeed; // the original speed of the enemy

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("IsRunning", true);
        target = GameObject.Find("Minotaur"); // set the target reference to the Minotaur
        originalSpeed = speed; // store the original speed

    }

    // Update is called once per frame
    void Update()
    {
        // calculate distance and direction to target
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        // move enemy towards target
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(lookTarget);
    }

            // Public method to handle the slowdown effect
    public void Slowdown(float amount)
    {
        m_Animator.SetBool("IsRunning", false);
        speed *= 0;

        // Ensure the speed doesn't go below zero
        if (speed < 0)
        {
            speed = 0;
        }
    }

    // Public method to reset the enemy's speed to its original value
    public void ResetSpeed()
    {
        speed = originalSpeed;
        m_Animator.SetBool("IsRunning", true);
    }

}
