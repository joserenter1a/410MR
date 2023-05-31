using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public int damage = 20;
    private Collider enemyCollider;
    private float knockback = 10f;
    private bool inRange;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MonsterAttack();
        }
    }

    void MonsterAttack()
    {
        if(inRange && enemyCollider != null)
        {
            // Perform damage logic here
            EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Rigidbody Human = enemyCollider.GetComponent<Rigidbody>();
            if(Human != null)
            {
                Vector3 kbDirection = (enemyCollider.transform.position - transform.position).normalized;
                Human.AddForce(kbDirection * knockback, ForceMode.Impulse);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            inRange = true;
            enemyCollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Human"))
        {
            inRange = false;
            enemyCollider = null;
        }
    }
}
