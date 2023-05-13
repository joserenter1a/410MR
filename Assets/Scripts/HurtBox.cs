using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public PlayerHealth Health;
    public PlayerController cc;

    private void Start() 
    {
        Health = transform.GetComponentInParent<PlayerHealth>();
        cc = transform.GetComponentInParent<PlayerController>();
    }
}
