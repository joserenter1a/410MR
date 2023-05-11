using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHumanMaleMovement : MonoBehaviour
{
    public GameObject target; // reference to the target game object
    public float speed; // the speed at which the enemy should move
    public Transform lookTarget;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Minotaur"); // set the target reference to the Minotaur
    }

    // Update is called once per frame
    void Update()
    {
        // calculate distance and direction to target
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        // move enemy towards target
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(lookTarget);
    }
}
