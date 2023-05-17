using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraOrbit : MonoBehaviour
{
    public GameObject Player;
    public float MouseSpeed = 3; 
    public float orbitDamping = 10;

    Vector3 localRot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
        localRot.x += Input.GetAxis("Mouse X") * MouseSpeed;
        localRot.y -= Input.GetAxis("Mouse Y") * MouseSpeed;
        

        localRot.y = Mathf.Clamp(localRot.y, 0f, 80f);

        Quaternion QT = Quaternion.Euler(localRot.y, localRot.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        // if want could also use this to unlock cursor but keep in screen
        // Cursor.lockState = CursorLockMode.Confined;
    }
}
