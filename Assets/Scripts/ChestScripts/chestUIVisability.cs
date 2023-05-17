using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chestUIVisability : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textMeshPro.enabled = true; // Show the TextMeshPro object
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textMeshPro.enabled = false; // Hide the TextMeshPro object
        }
    }
}
