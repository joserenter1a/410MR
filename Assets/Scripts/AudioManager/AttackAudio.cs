using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackAudio : MonoBehaviour
{
    private AudioSource Attack;

    private float desiredAttackCooldown = 350;
    private float attackCooldown = 0;

    private void Update()
    {

        Attack = GetComponent<AudioSource>();

        attackCooldown--;
        if(Input.GetMouseButtonDown(0) && attackCooldown <= 0)
        {
            Attack.Play();
            attackCooldown = desiredAttackCooldown;
        }
    }

}
