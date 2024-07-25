using UnityEngine;

public class OctopusSpawner : MonoBehaviour
{
    public GameObject octopusPrefab; // Assign the Octopus prefab here
    public float spawnInterval = 10f; // Time between spawns

    // Define the range for the spawning positions
    public float minX = 8f; // Minimum X position for spawning
    public float maxX = 10f; // Maximum X position for spawning
    public float minY = -5f; // Minimum Y position for spawning
    public float maxY = 5f; // Maximum Y position for spawning

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnOctopus();
            timer = spawnInterval;
        }
    }

    void SpawnOctopus()
    {
        // Generate random X and Y positions within the defined range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Instantiate the Octopus at the random position
        Instantiate(octopusPrefab, spawnPosition, Quaternion.identity);
    }
}
