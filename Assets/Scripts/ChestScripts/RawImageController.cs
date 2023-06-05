using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageController : MonoBehaviour
{
    public RawImage rawImage;
    //public Component SprintController
    public GameObject chest;
    public GameObject player;
    public float interactionDistance = 4f;

    private SprintController myScript;

    private void Start()
    {
        myScript = player.GetComponent<SprintController>();

        rawImage.enabled = false;
        myScript.enabled = false;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerNearChest())
        {
            rawImage.enabled = !rawImage.enabled;
            myScript.enabled = true;
            //gameObject.GetComponent<SprintController>().enabled = true;
        }
        if (! IsPlayerNearChest()) {
            rawImage.enabled = false;
        }

    }

    private bool IsPlayerNearChest()
    {
        if (Vector3.Distance(player.transform.position, chest.transform.position) <= interactionDistance)
        {
            return true;
        }

        return false;
    }
}