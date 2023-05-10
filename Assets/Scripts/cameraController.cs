using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    public Camera[] cameras;
    int currentCam = 0;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < cameras.Length; i++) 
        {
            cameras[i].gameObject.SetActive(false);
        }   
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cameras.Length; i++) 
        {
            float distanceCurrentCam = Vector3.Distance(player.transform.position, cameras[currentCam].transform.position);
            float distanceCheckedCam = Vector3.Distance(player.transform.position, cameras[i].transform.position);

            if (distanceCheckedCam < distanceCurrentCam) 
            {
                cameras[currentCam].gameObject.SetActive(false);
                cameras[i].gameObject.SetActive(true);
                currentCam = i;
            }
        }
        cameras[currentCam].transform.LookAt(player.transform);
    }
}
