using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAbility : MonoBehaviour
{
    // Public method to activate the slow ability and pass the slowdown amount as a parameter
    public void ActivateSlowAbility(float slowdownAmount)
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");

        foreach (GameObject humanObject in humanObjects)
        {
            // Check if the object has an EnemyHumanMaleMovement component
            EnemyHumanMaleMovement enemy = humanObject.GetComponent<EnemyHumanMaleMovement>();
            if (enemy != null)
            {
                enemy.Slowdown(slowdownAmount);
            }
            // You can also check for other components or perform additional actions
            // on the game objects with the "Human" tag here.
        }
    }
}
