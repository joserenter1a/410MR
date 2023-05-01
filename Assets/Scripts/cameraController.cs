using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //offset = (player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 3.0f);    
        offset = (player.transform.position) - new Vector3(0f, -3f, 3f);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
