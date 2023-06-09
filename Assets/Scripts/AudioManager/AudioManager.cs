using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private AudioSource background;
    private AudioSource Attack;
	private AudioSource walking;

    private float desiredAttackCooldown = 350;
    private float attackCooldown = 0;
 
    private void Start()
    {
        background = GetComponent<AudioSource>();
        background.Play();
    }

    private void Update()
    {
        walking = GetComponent<AudioSource>();

        bool walk = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
        if (walk)
        {
            if(!walking.isPlaying)
            {
			    walking.Play();

            }
		}
        else
        {
            walking.Stop();
        }
        Attack = GetComponent<AudioSource>();

        attackCooldown--;
        if(Input.GetMouseButtonDown(0) && attackCooldown <= 0)
        {
            Attack.Play();
            attackCooldown = desiredAttackCooldown;
        }
    }

}
