using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    public GameObject[] checkboxes;
    private bool hasKey = false; 
    private bool isActive = true;

    void Start()
    {
        isActive = checkboxes[0].activeSelf;
    }

    private void Update()
    {
        if (!hasKey)
        {
            checkboxes[0].SetActive(true);
        }
        else 
        {
            checkboxes[0].SetActive(false);
            checkboxes[1].SetActive(true);
        }
    }


}
