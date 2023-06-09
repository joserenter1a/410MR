using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Sprite fullHealth;
    public Sprite lilHurt;
    public Sprite halfHurt;
    public Sprite hellaHurt;
    public Sprite hellaDead;
    public Image[] hearts;

    public Health playerHealth;


    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.StartingHealth;
        for(int i = 0; i < hearts.Length; i ++)
        {
            hearts[i].enabled = false;
        }

        if(health == maxHealth)
        {
            hearts[0].enabled = true;
        }
        else if(health < maxHealth && health > maxHealth / 2)
        {
            hearts[1].enabled = true;
        }
        else if(health == maxHealth / 2)
        {
            hearts[2].enabled = true;
        }
        else if(health < maxHealth/2 && health > 0)
        {
            hearts[3].enabled = true;
        }
        else
        {
            hearts[4].enabled = true;
        }

    }
}
