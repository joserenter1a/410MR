using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAbility : MonoBehaviour
{
    public float slowDuration = 5f; // Duration of the slow effect
    public float slowAmount = 0.5f; // Amount to slow enemies by (e.g., 0.5 means 50% slower)
    public float cooldownTime = 30f; // Cooldown time for the ability

    private bool abilityReady = true; // Flag to track if the ability is ready to be used
    private float cooldownTimer = 0f; // Timer to track the remaining cooldown time

    // Method to activate the slow ability
    public void ActivateSlowAbility()
    {
        if (abilityReady)
        {
            // Apply slow effect to nearby enemies
            // Implement your slow effect logic here
            Debug.Log("Slow ability activated!");

            // Slow down enemies by adjusting the TimeScale factor
            Time.timeScale = slowAmount;

            // Start cooldown timer
            abilityReady = false;
            cooldownTimer = cooldownTime;

            // Invoke method to reset the ability after the duration
            Invoke("ResetSlowAbility", slowDuration);
        }
    }

    private void ResetSlowAbility()
    {
        // Reset ability state
        abilityReady = true;
        Time.timeScale = 1f; // Reset the TimeScale back to normal
        Debug.Log("Slow ability ready!");
    }

    private void Update()
    {
        // Update cooldown timer
        if (!abilityReady)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                abilityReady = true;
                Debug.Log("Slow ability ready!");
            }
        }
    }
}



