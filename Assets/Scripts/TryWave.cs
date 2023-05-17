using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Place all of the enemy prefabs into this list in the inspector
    [SerializeField] private List<GameObject> enemiesToSpawn = new List<GameObject>();

    // I use this as the maximum number of "enemies" I wanted on screen at once
    // Some of my prefabs included mulitple enemies, this was ok because they were all in the same prefab
    [SerializeField] private int spawnCount = 1;
    [SerializeField] private int currentCount = 0;

    // This is the amount of time between spawn calls
    [SerializeField] private float spawnTimer = 10;

    // This is the position I wanted to spawn the enemies in
    // this can be changed or messed with to spawn dynamically if you want
    [SerializeField] private Vector3 desiredPosition = new Vector3(0, 0, 0);
    

    private void Start()
    {
        // Start the first timer at beginning of game
        SpawnCountdown();
    }

    private void Update()
    {
        // If my current count ever drops below my desired number of enemies on the screen...
        if (currentCount < spawnCount)
        {
            // Start the countdown to a spawn
            SpawnCountdown();
        }
    }

    private IEnumerator SpawnCountdown()
    {
        // Wait spawnTimer seconds
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / spawnTimer;
            yield return null;
        }

        // Pick a random little guy
        int enemyPicked = Random.Range(0, enemiesToSpawn.Count - 1);
        
        // Increase the current count
        currentCount++;

        // Make the little guy
        Instantiate(enemiesToSpawn[enemyPicked], desiredPosition, Quaternion.identity);
    }

    // Call this from the destroyed enemy when the enemy dies, you can do so through a flyweight or elsewhere
    // You could also just edit the condition to be a very different thing that spawns, I made it this way
    // because in my gamejam game from last term (the mario one), I wanted to make absolutely sure that I
    // didn't spawn multiple prefabs at once
    public void EnemyDestroyed()
    {
        currentCount--;
    }
}