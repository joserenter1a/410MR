using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    public GameObject[] checkboxes;
    public PlayerController player;
    private bool hasKey ; 
    private bool isActive = true;

    void Start()
    {
        isActive = checkboxes[0].activeSelf;
    }

    private void Update()
    {
        hasKey = player.GetComponent<PlayerController>().hasKey;
        if (!hasKey)
        {
            checkboxes[0].SetActive(true);
            checkboxes[1].SetActive(false);
        }
        else 
        {
            checkboxes[0].SetActive(false);
            checkboxes[1].SetActive(true);
        }
    }


}
