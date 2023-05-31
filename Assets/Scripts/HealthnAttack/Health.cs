using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int StartingHealth = 100;
    public int health;


    void Start()
    {
        health = StartingHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined; 
            SceneManager.LoadScene("MainMenu");
            //Destroy(gameObject);
        }
    }
    
}
