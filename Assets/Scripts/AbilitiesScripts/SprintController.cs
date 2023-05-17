using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SprintController : MonoBehaviour
{
    public PlayerController playerController;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public float sprintMultiplier = 2f;

    private float originalMovementMultiplier;
    public bool isSprinting = false; // Make isSprinting public

    private void Start()
    {
        originalMovementMultiplier = playerController.movementMultiplier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(sprintKey))
        {
            StartSprinting();
        }
        else if (Input.GetKeyUp(sprintKey))
        {
            StopSprinting();
        }
    }

    private void StartSprinting()
    {
        isSprinting = true;
        playerController.movementMultiplier = originalMovementMultiplier * sprintMultiplier;
    }

    private void StopSprinting()
    {
        isSprinting = false;
        playerController.movementMultiplier = originalMovementMultiplier;
    }

    public bool IsSprinting()
    {
        return isSprinting;
    }
}