using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject tutorialUI;
    private bool isActive = true;

    void Start()
    {
        isActive = tutorialUI.activeSelf;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isActive = !isActive;
            setUIActive(isActive);
        }
    }

    private void setUIActive(bool active)
    {
        tutorialUI.SetActive(isActive);
    }
}
