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

    // Start is called before the first frame update
    void Start()
    {
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
            count += 1; 
            SetConqueredText();
            Destroy(gameObject);
                       
            
        }
    }
}
