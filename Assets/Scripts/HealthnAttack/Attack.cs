using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    Animator m_AnimatorHuman;

    private float desiredAttackCooldown = 350;
    private float attackCooldown = 0;
    public int damage = 20;
    private Collider enemyCollider;
    private float knockback = 10f;
    private bool inRange;
    void Update()
    {
        attackCooldown--;
        if(Input.GetMouseButtonDown(0) && attackCooldown <= 0)
        {
            attackCooldown = desiredAttackCooldown;
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
            m_AnimatorHuman = enemyCollider.GetComponent<Animator>();
            if(Human != null)
            {
                m_AnimatorHuman.SetBool("GetHit", true);
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
