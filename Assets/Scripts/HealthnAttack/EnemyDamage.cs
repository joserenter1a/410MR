using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    Animator m_Animator;
    public Health health;
    public int damage = 5;
    
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            health.TakeDamage(damage);
            m_Animator.Play("PunchRight");
            m_Animator.SetBool("IsRunning", true);
        }
    }

}
