using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackAudio : MonoBehaviour
{
    private AudioSource Attack;

    private void Update()
    {

        Attack = GetComponent<AudioSource>();

        if(Input.GetMouseButtonDown(0))
        {
            Attack.Play();
        }
    }

}
