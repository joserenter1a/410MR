using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyHealth : MonoBehaviour
{
    public TextMeshProUGUI Conquered;

    public int maxHealth = 25;
    public int currentHealth;
    private int count;
    private bool dead = false;
    private bool dying = false;

    public float deathCooldown = 5000;

    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();

        count = 0;
        currentHealth = maxHealth;
        SetConqueredText();

    }

    void SetConqueredText(){
        Conquered.text = "Defeated: " + count.ToString();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            m_Animator.Play("Death");
            m_Animator.SetBool("IsDying", true);
            count += 1; 
            SetConqueredText();
            dying = true;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (dying && !dead)
        {
            deathCooldown--;
        }
        if (deathCooldown <= 0)
        {
            dead = true;
        }
        if (dead)
        {
            Destroy(gameObject);
        }
    }
}
