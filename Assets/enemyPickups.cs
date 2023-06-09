using System.Collections;
using static System.Random;
using System.Collections.Generic;
using UnityEngine;

public class enemyPickups : MonoBehaviour
{
    public GameObject[] pickups;
    public int health;
    public Transform transform;
    public EnemyHealth enemy;

    // Update is called once per frame
    void Update()
    {
        health = enemy.currentHealth;

    }

    void OnTriggerEnter(Collider collider)
    {
        int i = Random.Range(0, 10);
        Vector3 position = transform.position;
        if(collider.gameObject.tag == "SpawnerHuman")
        {
            GameObject pickup = Instantiate(pickups[i], position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            pickup.SetActive(true);

        }

    }
}
